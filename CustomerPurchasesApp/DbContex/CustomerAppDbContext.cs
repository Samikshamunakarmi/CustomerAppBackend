using CustomerPurchasesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerPurchasesApp.DbContex
{
    public class CustomerAppDbContext : DbContext
    {
        public CustomerAppDbContext(DbContextOptions<CustomerAppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<CustomerDetail> CustomerDetails { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderDetail>()
        //    .HasOne(o => o.CustomerDetail)
        //    .WithMany(c => c.OrderDetail)
        //    .HasForeignKey(o => o.CustomerId);

        //    modelBuilder.Entity<OrderDetail>()
        //        .HasOne(o => o.Products)
        //        .WithMany(p => p.OrderDetail)
        //        .HasForeignKey(o => o.ProductId);
        //}

    }
}
