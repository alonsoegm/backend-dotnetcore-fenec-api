using FenecApi.Configurations;
using FenecApi.Models;
using FenecApi.SeedData;
using Microsoft.EntityFrameworkCore;

namespace FenecApi.Data
{
	/// <summary>
	/// Database context for Fenec API, handling entity configurations and database interactions.
	/// </summary>
	public class FenecDbContext : DbContext
	{
		public FenecDbContext(DbContextOptions<FenecDbContext> options) : base(options) { }

		/// <summary>
		/// Represents the Products table.
		/// </summary>
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// Represents the Categories table.
		/// </summary>
		public DbSet<Category> Categories { get; set; }

		/// <summary>
		/// Represents the Orders table.
		/// </summary>
		public DbSet<Order> Orders { get; set; }

		/// <summary>
		/// Represents the OrderItems table.
		/// </summary>
		public DbSet<OrderItem> OrderItems { get; set; }

		/// <summary>
		/// Configures entity relationships and applies initial seed data.
		/// </summary>
		/// <param name="modelBuilder">The model builder instance.</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Apply entity configurations
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

			// Apply seed data
			modelBuilder.Entity<Category>().HasData(CategorySeedData.GetCategories());
			modelBuilder.Entity<Product>().HasData(ProductSeedData.GetProducts());
			modelBuilder.Entity<Order>().HasData(OrderSeedData.GetOrders());
			modelBuilder.Entity<OrderItem>().HasData(OrderItemSeedData.GetOrderItems());

			base.OnModelCreating(modelBuilder);
		}
	}
}
