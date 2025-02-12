namespace FenecApi.Models;
/// <summary>
/// Represents a customer order.
/// </summary>
public class Order
{
	public int Id { get; set; }

	/// <summary>
	/// Date when the order was created. Default is UTC Now.
	/// </summary>
	public DateTime OrderDate { get; set; } = DateTime.UtcNow;

	/// <summary>
	/// Customer's name who placed the order.
	/// </summary>
	public string CustomerName { get; set; } = string.Empty;

	/// <summary>
	/// Navigation property containing all order items.
	/// </summary>
	public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
