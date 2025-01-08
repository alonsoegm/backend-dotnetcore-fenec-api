namespace FenecApi.Models
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;
		public string CustomerName { get; set; } = string.Empty;

		// Navigation property
		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
