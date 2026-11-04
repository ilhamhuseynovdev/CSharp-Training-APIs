using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Production_ECommerce_Engine.Data;
using Production_ECommerce_Engine.DTOs;
using Production_ECommerce_Engine.Models;
using System.Threading.Tasks;
using Production_ECommerce_Engine.Services.Interfaces;

namespace Production_ECommerce_Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]int pageNumber,int pageSize)
        {
            var result = await _productService.GetAllProductsAsync(pageNumber,pageSize);
            return CreateActionResult(result);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var result = await _productService.CreateProductAsync(dto);
            return CreateActionResult(result);
        }

        [HttpPost("create-user")] //That's just for a test, in real project you should use real User model for that you need Microsoft.AspNetCore.Identity.EntityFrameworkCore package and inherit from IdentityUser for User model and IdentityDbCotext<User> for AppDbContext
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _productService.CreateUserAsync(dto);
            return CreateActionResult(result);
        }


    }
}
