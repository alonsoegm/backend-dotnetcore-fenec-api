namespace FenecApi.Models;
/// <summary>
/// Represents a product in the system.
/// </summary>
public class Product
{
	public int Id { get; set; }

	/// <summary>
	/// Name of the product.
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Description of the product.
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// Price of the product.
	/// </summary>
	public decimal Price { get; set; }

	/// <summary>
	/// Available stock quantity.
	/// </summary>
	public int Stock { get; set; }

	/// <summary>
	/// Foreign key referencing the Category entity.
	/// </summary>
	public int CategoryId { get; set; }

	/// <summary>
	/// Navigation property to access the product's category.
	/// </summary>
	public Category Category { get; set; } = null!;
}
