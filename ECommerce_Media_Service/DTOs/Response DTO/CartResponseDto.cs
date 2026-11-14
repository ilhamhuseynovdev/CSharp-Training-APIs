namespace ECommerce_Media_Service.DTOs.Response_DTO
{
    public class CartResponseDto
    {
        public List<AllCartsDto> Items { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal GrandTotalUsd { get; set; }
    }
}
