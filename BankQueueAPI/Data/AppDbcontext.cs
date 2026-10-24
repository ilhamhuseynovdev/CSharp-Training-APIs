using BankQueueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankQueueAPI.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }

        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }



    }
}
