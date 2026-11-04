using Production_ECommerce_Engine.Models;

namespace Production_ECommerce_Engine.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
