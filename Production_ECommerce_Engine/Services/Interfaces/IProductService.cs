using Production_ECommerce_Engine.DTOs;
using Production_ECommerce_Engine.Models;
using Production_ECommerce_Engine.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Production_ECommerce_Engine.Services.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult<List<Product>>> GetAllProductsAsync(int pageNumber,int pageSize);
        Task<ServiceResult<bool>> CreateProductAsync(CreateProductDto dto);
        Task<ServiceResult<bool>> CreateUserAsync(CreateUserDto dto);

    }
}
