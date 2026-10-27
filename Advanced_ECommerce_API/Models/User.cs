using Advanced_ECommerce_API.Models;

namespace Advanced_ECommerce_API.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
