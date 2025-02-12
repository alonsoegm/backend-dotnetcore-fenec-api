using FenecApi.Data;
using FenecApi.Models;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Repositories;
/// <summary>
/// Repository implementation for managing Order data operations.
/// </summary>
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
	public OrderRepository(FenecDbContext context) : base(context) { }
}
