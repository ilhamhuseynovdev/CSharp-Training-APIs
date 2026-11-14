using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce_Media_Service.Data;
using ECommerce_Media_Service.DTOs;
using ECommerce_Media_Service.Models;
using System.Threading.Tasks;
using ECommerce_Media_Service.Services.Interfaces;

namespace ECommerce_Media_Service.Controllers
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
        public async Task<IActionResult> CreateProduct([FromForm]CreateProductDto dto)
        {
            var result = await _productService.CreateProductAsync(dto);



            return CreateActionResult(result);
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _productService.CreateUserAsync(dto);
            return CreateActionResult(result);
        }


    }
}
