namespace MiniE_CommerceCartAPI.Models
{
    public class Cart : BaseEntity
    {

        public bool IsActive { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
