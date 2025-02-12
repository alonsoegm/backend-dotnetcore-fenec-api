namespace FenecApi.Models;
/// <summary>
/// Represents an item in an order.
/// </summary>
public class OrderItem
{
	public int Id { get; set; }

	/// <summary>
	/// Quantity of the product in the order.
	/// </summary>
	public int Quantity { get; set; }

	/// <summary>
	/// Foreign key referencing the Order entity.
	/// </summary>
	public int OrderId { get; set; }

	/// <summary>
	/// Foreign key referencing the Product entity.
	/// </summary>
	public int ProductId { get; set; }

	/// <summary>
	/// Navigation property to access the related order.
	/// </summary>
	public Order Order { get; set; } = null!;

	/// <summary>
	/// Navigation property to access the related product.
	/// </summary>
	public Product Product { get; set; } = null!;
}