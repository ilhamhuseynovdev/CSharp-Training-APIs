using Advanced_ECommerce_API.Models;

namespace Advanced_ECommerce_API.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
