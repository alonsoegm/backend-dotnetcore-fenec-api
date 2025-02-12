using FenecApi.Data;
using FenecApi.Models;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Repositories;
/// <summary>
/// Repository implementation for managing OrderItem data operations.
/// </summary>
public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
	public OrderItemRepository(FenecDbContext context) : base(context) { }
}

