using FenecApi.Models;

namespace FenecApi.SeedData;

/// <summary>
/// Provides initial seed data for Orders.
/// </summary>
public static class OrderSeedData
{
	public static List<Order> GetOrders() => new()
		{
			new Order { Id = 1, CustomerName = "John Doe", OrderDate = DateTime.UtcNow },
			new Order { Id = 2, CustomerName = "Alice Smith", OrderDate = DateTime.UtcNow.AddDays(-1) },
			new Order { Id = 3, CustomerName = "Bob Johnson", OrderDate = DateTime.UtcNow.AddDays(-2) }
		};
}

