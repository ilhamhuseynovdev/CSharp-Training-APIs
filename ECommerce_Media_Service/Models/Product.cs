using ECommerce_Media_Service.Models;

namespace ECommerce_Media_Service.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }
    }
}
