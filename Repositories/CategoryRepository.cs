using FenecApi.Data;
using FenecApi.Models;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Repositories;

/// <summary>
/// Repository implementation for managing Category data operations.
/// </summary>
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
	/// <summary>
	/// Repository implementation for managing Category data operations.
	/// </summary>
	public CategoryRepository(FenecDbContext context) : base(context) { }
}