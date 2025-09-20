
using EcomLDC.Domain.Entities.Carts;
using EcomLDC.Domain.Entities.Orders;
using EcomLDC.Domain.Entities.Products;
using EcomLDC.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EcomLDC.Infrastructure.Persistence
{
    public class EcomLDCDbContext : DbContext
    {
        public EcomLDCDbContext(DbContextOptions<EcomLDCDbContext> options) : base(options)
        {
        }
        // tables
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
         
        }
    }
}
