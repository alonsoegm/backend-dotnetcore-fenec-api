using FenecApi.Models;

namespace FenecApi.SeedData;
/// <summary>
/// Provides initial seed data for Categories.
/// </summary>
public static class CategorySeedData
{
	public static List<Category> GetCategories() => new()
		{
			new Category { Id = 1, Name = "Electronics" },
			new Category { Id = 2, Name = "Clothing" },
			new Category { Id = 3, Name = "Home Appliances" },
			new Category { Id = 4, Name = "Books" },
			new Category { Id = 5, Name = "Toys" }
		};
}

