using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Advanced_ECommerce_API.Data;
using Advanced_ECommerce_API.DTOs;
using Advanced_ECommerce_API.Models;
using System.Threading.Tasks;
using Advanced_ECommerce_API.Services.Interfaces;

namespace Advanced_ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : CustomBaseController
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost("addtocart")]
        public async Task<IActionResult> AddToCart(int UserId, int ProductId, int Quantity)
        {

            var result = await _cartService.AddToCartAsync(UserId, ProductId, Quantity);

            return CreateActionResult(result);
        }

        [HttpGet("allcarts/{userId}")]
        public async Task<IActionResult> AllCarts(int userId)
        {
            var result = await _cartService.GetActiveCartAsync(userId);

            return CreateActionResult(result);
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(int userId)
        {
            var result = await _cartService.CheckoutAsync(userId);
            return CreateActionResult(result);
        }

    }
}
