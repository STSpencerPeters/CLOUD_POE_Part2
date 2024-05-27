using CLOUD_POE_Part2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CLOUD_POE_Part2.Data
{
    public class SystemDbContext : IdentityDbContext<IdentityUser>
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.Admin)
            .WithMany(a => a.Products)
            .HasForeignKey(p => p.AdminID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
