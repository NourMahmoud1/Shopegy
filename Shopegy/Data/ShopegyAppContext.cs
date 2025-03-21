
using Microsoft.EntityFrameworkCore;
using Models;
using Shopegy.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Data
{
    public class ShopegyAppContext : DbContext
    {
        public ShopegyAppContext(DbContextOptions<ShopegyAppContext> options) : base(options)
        {
        }

        // Existing DbSet properties
        public DbSet<Shipping> Shipping { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }

        // Add DbSet properties for Order and Payment
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategorie> ProductCategories { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//    base.OnModelCreating(modelBuilder);

		//    // Configure the relationship between Order and Payment
		//    modelBuilder.Entity<Payment>()
		//        .HasOne(p => p.Order)
		//        .WithMany(o => o.Payment) // Assuming you added a navigation property in Order
		//        .HasForeignKey(p => p.OrderID)
		//        .OnDelete(DeleteBehavior.Cascade); // Cascade delete if Order is deleted

		//    // Add any additional configurations for Shipping and ShippingAddress if needed
		//}
	}
}