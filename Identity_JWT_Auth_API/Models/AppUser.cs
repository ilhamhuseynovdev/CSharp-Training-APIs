using Microsoft.AspNetCore.Identity;

namespace Identity_JWT_Auth_API.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
