namespace FenecApi.Models;
/// <summary>
/// Represents a product category.
/// </summary>
public class Category
{
	public int Id { get; set; }

	/// <summary>
	/// Name of the category.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Navigation property containing all products within this category.
	/// </summary>
	public ICollection<Product> Products { get; set; } = new List<Product>();
}
