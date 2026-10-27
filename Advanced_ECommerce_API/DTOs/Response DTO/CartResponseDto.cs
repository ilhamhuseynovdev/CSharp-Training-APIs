namespace Advanced_ECommerce_API.DTOs.Response_DTO
{
    public class CartResponseDto
    {
        public List<AllCartsDto> Items { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
