using MiniE_CommerceCartAPI.Models;

namespace MiniE_CommerceCartAPI.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
