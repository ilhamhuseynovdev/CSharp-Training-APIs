using Advanced_ECommerce_API.DTOs;
using Advanced_ECommerce_API.Models;
using Advanced_ECommerce_API.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_ECommerce_API.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<List<Product>>> GetAllProductsAsync();
        Task<ServiceResult<bool>> CreateProductAsync(CreateProductDto dto);
        Task<ServiceResult<bool>> CreateUserAsync(CreateUserDto dto);

    }
}
