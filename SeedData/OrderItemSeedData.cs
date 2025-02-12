using FenecApi.Models;
namespace FenecApi.SeedData;

/// <summary>
/// Provides initial seed data for Order Items.
/// </summary>
public static class OrderItemSeedData
{
	public static List<OrderItem> GetOrderItems() => new()
		{
			new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
			new OrderItem { Id = 2, OrderId = 1, ProductId = 3, Quantity = 2 },
			new OrderItem { Id = 3, OrderId = 2, ProductId = 5, Quantity = 1 },
			new OrderItem { Id = 4, OrderId = 2, ProductId = 2, Quantity = 1 },
			new OrderItem { Id = 5, OrderId = 3, ProductId = 4, Quantity = 1 },
			new OrderItem { Id = 6, OrderId = 3, ProductId = 6, Quantity = 3 }
		};
}

