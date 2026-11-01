using Identity_JWT_Auth_API.DTOs;
using Identity_JWT_Auth_API.Utilities.Result;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Identity_JWT_Auth_API.Services
{
    public interface IAuthService
    {
        public Task<ServiceResult<bool>> RegisterAsync(RegisterDto dto);
        public Task<ServiceResult<TokenResponseDto>> LoginAsync(LoginDto dto);
    }
}
