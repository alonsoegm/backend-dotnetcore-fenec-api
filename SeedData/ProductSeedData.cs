using FenecApi.Models;

namespace FenecApi.SeedData;
/// <summary>
/// Provides initial seed data for Products.
/// </summary>
public static class ProductSeedData
{
	public static List<Product> GetProducts() => new()
		{
			new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 1200.99M, Stock = 10, CategoryId = 1 },
			new Product { Id = 2, Name = "Smartphone", Description = "Latest generation smartphone", Price = 799.99M, Stock = 25, CategoryId = 1 },
			new Product { Id = 3, Name = "T-Shirt", Description = "Cotton t-shirt", Price = 19.99M, Stock = 100, CategoryId = 2 },
			new Product { Id = 4, Name = "Microwave", Description = "800W microwave oven", Price = 150.50M, Stock = 15, CategoryId = 3 },
			new Product { Id = 5, Name = "Fiction Book", Description = "Bestselling fiction novel", Price = 12.99M, Stock = 50, CategoryId = 4 },
			new Product { Id = 6, Name = "Toy Car", Description = "Remote control toy car", Price = 34.99M, Stock = 30, CategoryId = 5 }
		};
}
