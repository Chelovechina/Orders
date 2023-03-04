using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.DAL.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> item { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
        public DbSet<Provider> provider { get; set; }
    }
}
