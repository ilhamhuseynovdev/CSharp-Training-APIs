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
    public class CartsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("addtocart")]
        public async Task<IActionResult> AddToCart(int UserId, int ProductId, int Quantity)
        {
            var isExistsUser = await _context.Users.AnyAsync(u => u.Id == UserId);
            if (!isExistsUser) return NotFound("Wrong user Id please try again");

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
            if (product is null) return NotFound("Wrong product Id please try again");

            if (product.StockQuantity < Quantity) return BadRequest("There is not enough product");

            var cart = await _context.Carts.FirstOrDefaultAsync(p => p.UserId == UserId);
            if (cart is null || cart.IsActive == false)
            {
                cart = new Cart()
                {
                    UserId = UserId,
                    IsActive = true,
                };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == ProductId && ci.CartId == cart.Id);
            if (cartItem is null)
            {
                cartItem = new CartItem()
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = Quantity,
                };

                //product.StockQuantity -= Quantity;

                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync();

                return Ok("Added to card");
            }

            cartItem.Quantity += Quantity;
            //product.StockQuantity -= Quantity;

            await _context.SaveChangesAsync();

            return Ok("Added to card");
        }

        [HttpGet("allcarts/{userId}")]
        public async Task<IActionResult> AllCarts(int userId)
        {
            var user = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!user) return NotFound("User Not Found");

            var cart = await _context.Carts
                 .Include(c => c.CartItems)
                     .ThenInclude(ci => ci.Product)
                 .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive == true);
            if (cart is null || cart.CartItems.Count == 0) return NotFound("Active Card not founded");

            var dto = cart.CartItems.Select(ci => new AllCartsDto
            {
                ProductName = ci.Product.Name,
                Price = ci.Product.Price,
                Quantity = ci.Quantity,
                TotalPrice = ci.Quantity * ci.Product.Price,
            }).ToList();

            var cartTotal = dto.Sum(d => d.TotalPrice);

            return Ok(new { Items = dto, GrandTotal = cartTotal });
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout(int userId)
        {
            var cart = await _context.Carts
             .Include(c => c.CartItems)
                 .ThenInclude(ci => ci.Product)
             .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive == true);
            if (cart == null || !cart.CartItems.Any()) return BadRequest("Cart is empty.");

            foreach (var ci in cart.CartItems)
            {
                if (ci.Product.StockQuantity < ci.Quantity)
                {
                    return BadRequest($"Not enough stock for {ci.Product.Name} Remaining: {ci.Product.StockQuantity}");
                }
                ci.Product.StockQuantity -= ci.Quantity;  
            }


            cart.IsActive = false;

            await _context.SaveChangesAsync();
            return Ok("Successfully");
        }

    }
}
