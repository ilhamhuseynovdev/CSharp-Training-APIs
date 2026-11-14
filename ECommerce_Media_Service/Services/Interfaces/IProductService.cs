using ECommerce_Media_Service.DTOs;
using ECommerce_Media_Service.Models;
using ECommerce_Media_Service.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Media_Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<List<Product>>> GetAllProductsAsync(int pageNumber,int pageSize);
        Task<ServiceResult<bool>> CreateProductAsync(CreateProductDto dto);
        Task<ServiceResult<bool>> CreateUserAsync(CreateUserDto dto);

    }
}
