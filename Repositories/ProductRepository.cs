using FenecApi.Data;
using FenecApi.Models;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Repositories;
/// <summary>
/// Repository implementation for managing Product data operations.
/// </summary>
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	public ProductRepository(FenecDbContext context) : base(context) { }
}
