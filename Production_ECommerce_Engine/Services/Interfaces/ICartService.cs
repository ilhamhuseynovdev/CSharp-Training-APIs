using Production_ECommerce_Engine.DTOs.Response_DTO;
using Production_ECommerce_Engine.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Production_ECommerce_Engine.Services.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResult<bool>> AddToCartAsync(int userId, int productId, int quantity);
        Task<ServiceResult<CartResponseDto>> GetActiveCartAsync(int userId);
        Task<ServiceResult<bool>> CheckoutAsync(int userId);
    }
}
