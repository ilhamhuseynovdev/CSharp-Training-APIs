using Advanced_ECommerce_API.DTOs.Response_DTO;
using Advanced_ECommerce_API.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_ECommerce_API.Services.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResult<bool>> AddToCartAsync(int userId, int productId, int quantity);
        Task<ServiceResult<CartResponseDto>> GetActiveCartAsync(int userId);
        Task<ServiceResult<bool>> CheckoutAsync(int userId);
    }
}
