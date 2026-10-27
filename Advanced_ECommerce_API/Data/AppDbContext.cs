using Microsoft.EntityFrameworkCore;
using Advanced_ECommerce_API.Models;

namespace Advanced_ECommerce_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Cart>()
                .Property(c=>c.IsActive)
                .HasDefaultValueSql("True");
        }

    }
}
