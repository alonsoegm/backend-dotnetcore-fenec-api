using FenecApi.Models;

namespace FenecApi.SeedData
{
	public static class CategorySeedData
	{
		public static List<Category> GetCategories()
		{
			return new List<Category>
			{
				new Category { Id = 1, Name = "Electronics" },
				new Category { Id = 2, Name = "Clothing" },
				new Category { Id = 3, Name = "Books" },
				new Category { Id = 4, Name = "Home & Kitchen" }
			};
		}
	}
}
