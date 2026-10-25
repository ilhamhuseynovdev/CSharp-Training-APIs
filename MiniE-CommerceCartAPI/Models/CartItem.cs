namespace MiniE_CommerceCartAPI.Models
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
