using Production_ECommerce_Engine.Models;

namespace Production_ECommerce_Engine.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
