using Identity_JWT_Auth_API.Data;
using Identity_JWT_Auth_API.DTOs;
using Identity_JWT_Auth_API.Models;
using Identity_JWT_Auth_API.Utilities.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity_JWT_Auth_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, UserManager<AppUser> userManager,IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ServiceResult<bool>> RegisterAsync(RegisterDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user != null) return ServiceResult<bool>.Failure("User already exists via that email", 400);

            user = new AppUser()
            {
                UserName = dto.UserName,
                FullName = dto.FullName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                string message = string.Empty;

                foreach (var error in result.Errors)
                {
                    message += error.Description;
                }
                // message = string.Join(" ",result.Error.Select(e=>e.Description)) bele de yazmaq olardi ve ya menim ilk yazdiqim foreach ile 
                return ServiceResult<bool>.Failure(message, 400);
            }



            return ServiceResult<bool>.Success(true,"Successfully created");
        }




        public async Task<ServiceResult<TokenResponseDto>> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == dto.Email);
            if (user == null) return ServiceResult<TokenResponseDto>.Failure("Email or password is incorrect",400);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user,dto.Password);
            if (!isPasswordValid) return ServiceResult<TokenResponseDto>.Failure("Email or password is incorrect", 400);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("FullName",user.FullName ?? "")
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var expireMinutes = Convert.ToInt32(_configuration["JWT:ExpireMinutes"]);

            var expirationTime = DateTime.UtcNow.AddMinutes(expireMinutes);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires:expirationTime,
                signingCredentials:new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256)
                
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new TokenResponseDto
            {
                Token = tokenString,
                ExpireDate = expirationTime,
            };


            return ServiceResult<TokenResponseDto>.Success(response,"Login succesfully",200);
        }

    }
}
