using FenecApi.Configurations;
using FenecApi.Models;
using FenecApi.SeedData;
using Microsoft.EntityFrameworkCore;

namespace FenecApi.Data
{
	public class FenecDbContext : DbContext
	{
		public FenecDbContext(DbContextOptions<FenecDbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

			// Seed data for Categories
			modelBuilder.Entity<Category>().HasData(CategorySeedData.GetCategories());

			base.OnModelCreating(modelBuilder);

		}
	}}
