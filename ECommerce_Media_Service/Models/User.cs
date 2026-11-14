using ECommerce_Media_Service.Models;

namespace ECommerce_Media_Service.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
