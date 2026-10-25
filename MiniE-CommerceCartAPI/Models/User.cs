using MiniE_CommerceCartAPI.Models;

namespace MiniE_CommerceCartAPI.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
