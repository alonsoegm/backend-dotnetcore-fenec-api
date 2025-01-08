using FenecApi.Data;
using FenecApi.Models;
using FenecApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FenecApi.Repositories
{
	/// <summary>
	/// Repository implementation for managing Category data operations.
	/// </summary>
	public class CategoryRepository : ICategoryRepository
	{
		private readonly FenecDbContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoryRepository"/> class.
		/// </summary>
		/// <param name="context">The database context to use for Category operations.</param>
		public CategoryRepository(FenecDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieves a list of all categories from the database.
		/// </summary>
		/// <returns>A list of Category objects.</returns>
		public async Task<List<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		/// <summary>
		/// Retrieves a category by its unique identifier from the database.
		/// </summary>
		/// <param name="id">The unique identifier of the category.</param>
		/// <returns>A Category object if found; otherwise, null.</returns>
		public async Task<Category?> GetByIdAsync(int id)
		{
			return await _context.Categories.FindAsync(id);
		}

		/// <summary>
		/// Adds a new category to the database.
		/// </summary>
		/// <param name="category">The Category object to add.</param>
		public async Task AddAsync(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing category in the database.
		/// </summary>
		/// <param name="category">The Category object with updated values.</param>
		public async Task UpdateAsync(Category category)
		{
			_context.Categories.Update(category);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes a category from the database by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the category to delete.</param>
		public async Task DeleteAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category != null)
			{
				_context.Categories.Remove(category);
				await _context.SaveChangesAsync();
			}
		}
	}
}

