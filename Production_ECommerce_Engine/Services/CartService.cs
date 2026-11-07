using Production_ECommerce_Engine.Data;
using Production_ECommerce_Engine.DTOs;
using Production_ECommerce_Engine.DTOs.Response_DTO;
using Production_ECommerce_Engine.Models;
using Production_ECommerce_Engine.Services.Interfaces;
using Production_ECommerce_Engine.Utilities.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Production_ECommerce_Engine.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;
        private readonly ICurrencyService _currencyService;

        public CartService(AppDbContext context,ICurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }

        public async Task<ServiceResult<bool>> AddToCartAsync(int userId, int productId, int quantity)
        {
            var isExistsUser = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!isExistsUser) return ServiceResult<bool>.Failure("Wrong user Id please try again",404);

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null) return ServiceResult<bool>.Failure("Wrong product Id please try again",404);

            if (product.StockQuantity < quantity) return ServiceResult<bool>.Failure("There is not enough product",400);

            var cart = await _context.Carts.FirstOrDefaultAsync(p => p.UserId == userId);
            if (cart is null || cart.IsActive == false)
            {
                cart = new Cart()
                {
                    UserId = userId,
                    IsActive = true,
                };
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.CartId == cart.Id);
            if (cartItem is null)
            {
                cartItem = new CartItem()
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                };


                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync();

                return ServiceResult<bool>.Success(true,"Added to card",200);
            }

            cartItem.Quantity += quantity;
            //product.StockQuantity -= Quantity;

            await _context.SaveChangesAsync();

            return ServiceResult<bool>.Success(true, "Added to card", 200);
        }

        public async Task<ServiceResult<bool>> CheckoutAsync(int userId)
        {
            var cart = await _context.Carts
           .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Product)
           .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive == true);
            if (cart == null || !cart.CartItems.Any()) return ServiceResult<bool>.Failure("Cart is empty.",400);

            foreach (var ci in cart.CartItems)
            {
                if (ci.Product.StockQuantity < ci.Quantity)
                {
                    return ServiceResult<bool>.Failure($"Not enough stock for {ci.Product.Name} Remaining: {ci.Product.StockQuantity}",400);
                }
                ci.Product.StockQuantity -= ci.Quantity;
            }


            cart.IsActive = false;

            await _context.SaveChangesAsync();
            return ServiceResult<bool>.Success(true,"Successfully",200);
        }

        public async Task<ServiceResult<CartResponseDto>> GetActiveCartAsync(int userId)
        {
            var user = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!user) return ServiceResult<CartResponseDto>.Failure("User Not Found",404);

            var cart = await _context.Carts
                 .Include(c => c.CartItems)
                     .ThenInclude(ci => ci.Product)
                 .FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive == true);
            if (cart is null || cart.CartItems.Count == 0) return ServiceResult<CartResponseDto>.Failure("Active Card not founded",404);

            var itemsDto = cart.CartItems.Select(ci => new AllCartsDto
            {
                ProductName = ci.Product.Name,
                Price = ci.Product.Price,
                Quantity = ci.Quantity,
                TotalPrice = ci.Quantity * ci.Product.Price,
            }).ToList();

            var cartTotal = itemsDto.Sum(d => d.TotalPrice);

            decimal usdRate = await _currencyService.GetUsdRateAsync();

            var responseDto = new CartResponseDto
            {
                Items = itemsDto,
                GrandTotal = cartTotal,
                GrandTotalUsd = cartTotal*usdRate,
            };

            return ServiceResult<CartResponseDto>.Success(responseDto, "Cart retrieved successfully",200);
        }
    }
}
