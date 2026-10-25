using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniE_CommerceCartAPI.Data;
using MiniE_CommerceCartAPI.DTOs;
using MiniE_CommerceCartAPI.Models;
using System.Threading.Tasks;

namespace MiniE_CommerceCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            if (products.Count == 0) return BadRequest("There is no any product,yet");

            return Ok(products);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var isExists = await _context.Products.AnyAsync(p=>p.Name.ToLower().Trim() == dto.Name.ToLower().Trim());
            if (isExists) return BadRequest("Product is already exists");

            var product = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Created successfully");
        }

        [HttpPost("create-user")] //That's just for a test, in real project you should use real User model for that you need Microsoft.AspNetCore.Identity.EntityFrameworkCore package and inherit from IdentityUser for User model and IdentityDbCotext<User> for AppDbContext
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var isExists = await _context.Users.AnyAsync(u => u.Email.ToLower().Trim() == dto.Email.ToLower().Trim());
            if (isExists) return BadRequest("User is already exists with that email");

            var user = new User()
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("Created acc successfully");
        }


    }
}
