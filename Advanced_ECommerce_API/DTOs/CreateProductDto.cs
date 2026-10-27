namespace Advanced_ECommerce_API.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
