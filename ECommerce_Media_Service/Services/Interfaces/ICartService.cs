using ECommerce_Media_Service.DTOs.Response_DTO;
using ECommerce_Media_Service.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Media_Service.Services.Interfaces
{
    public interface ICartService
    {
        Task<ServiceResult<bool>> AddToCartAsync(int userId, int productId, int quantity);
        Task<ServiceResult<CartResponseDto>> GetActiveCartAsync(int userId);
        Task<ServiceResult<bool>> CheckoutAsync(int userId);
    }
}
