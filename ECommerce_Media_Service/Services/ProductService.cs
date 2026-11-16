using ECommerce_Media_Service.Data;
using ECommerce_Media_Service.DTOs;
using ECommerce_Media_Service.Models;
using ECommerce_Media_Service.Services.Interfaces;
using ECommerce_Media_Service.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce_Media_Service.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public ProductService(AppDbContext context,IFileService fileService )
        {
            _context = context;
            _fileService = fileService;
        }
        public async Task<ServiceResult<bool>> CreateProductAsync(CreateProductDto dto)
        {
            var isExists = await _context.Products.AnyAsync(p => p.Name.ToLower().Trim() == dto.Name.ToLower().Trim());
            if (isExists) return ServiceResult<bool>.Failure("Product is already exists",400);

            if(dto.ImageUrl is null)
            {
                return ServiceResult<bool>.Failure("Image cant be null", 400);
            }


            var imageUrl = await _fileService.UploadFileAsync(dto.ImageUrl,"images") ;
            if (!imageUrl.IsSuccess)
            {
                return ServiceResult<bool>.Failure(imageUrl.Message, imageUrl.StatusCode);
            }


            var product = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                ImageUrl = imageUrl.Data,
            };

            

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Success(true,"Created successfully");
        }

        public async Task<ServiceResult<bool>> CreateUserAsync(CreateUserDto dto)
        {
            var isExists = await _context.Users.AnyAsync(u => u.Email.ToLower().Trim() == dto.Email.ToLower().Trim());
            if (isExists) return ServiceResult<bool>.Failure("User is already exists with that email", 400);

            var user = new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Success(true,"Created acc successfully");
        }

        public async Task<ServiceResult<List<Product>>> GetAllProductsAsync(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 0 : pageNumber-1;
            //pageNumber -= 1;

            pageSize = pageSize < 1 ? 1 : pageSize;

            var products = await _context.Products
                .Skip(pageNumber*pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (products.Count == 0) return ServiceResult<List<Product>>.Failure("Product not founded", 404);

            return ServiceResult<List<Product>>.Success(products);
        }

        public async Task<ServiceResult<bool>> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            if (dto is null) return ServiceResult<bool>.Failure("Data cant be null",400);

            var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id == id);
            if (product == null) return ServiceResult<bool>.Failure("Product not found",404);

            var isExistsName = await _context.Products.AnyAsync(p=>p.Name == dto.Name && p.Id != id);
            if (isExistsName) return ServiceResult<bool>.Failure("Name already used",400);

            if (dto.ImageUrl is not null)
            {
                var uploadResult = await _fileService.UploadFileAsync(dto.ImageUrl,"images");

                if (!uploadResult.IsSuccess)
                {
                    return ServiceResult<bool>.Failure(uploadResult.Message, uploadResult.StatusCode);
                }

                var existsImage = product.ImageUrl;

                if (!string.IsNullOrEmpty(product.ImageUrl))
                    _fileService.DeleteFile(product.ImageUrl);

                product.ImageUrl = uploadResult.Data;
            }

            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.Name = dto.Name;

            await _context.SaveChangesAsync();


            return ServiceResult<bool>.Success(true);
        }
    }
}
