using Production_ECommerce_Engine.Data;
using Production_ECommerce_Engine.DTOs;
using Production_ECommerce_Engine.Models;
using Production_ECommerce_Engine.Services.Interfaces;
using Production_ECommerce_Engine.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Production_ECommerce_Engine.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context )
        {
            _context = context;
        }
        public async Task<ServiceResult<bool>> CreateProductAsync(CreateProductDto dto)
        {
            var isExists = await _context.Products.AnyAsync(p => p.Name.ToLower().Trim() == dto.Name.ToLower().Trim());
            if (isExists) return ServiceResult<bool>.Failure("Product is already exists",400);

            var product = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
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
    }
}
