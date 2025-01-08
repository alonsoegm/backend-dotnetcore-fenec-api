using FenecApi.Models;

namespace FenecApi.Repositories.Interfaces
{
	/// <summary>
	/// Interface that defines the contract for Category repository operations.
	/// </summary>
	public interface ICategoryRepository
	{
		/// <summary>
		/// Retrieves a list of all categories from the database.
		/// </summary>
		/// <returns>A list of Category objects.</returns>
		Task<List<Category>> GetAllAsync();

		/// <summary>
		/// Retrieves a category by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the category.</param>
		/// <returns>A Category object if found; otherwise, null.</returns>
		Task<Category?> GetByIdAsync(int id);

		/// <summary>
		/// Adds a new category to the database.
		/// </summary>
		/// <param name="category">The Category object to add.</param>
		Task AddAsync(Category category);

		/// <summary>
		/// Updates an existing category in the database.
		/// </summary>
		/// <param name="category">The Category object with updated values.</param>
		Task UpdateAsync(Category category);

		/// <summary>
		/// Deletes a category from the database by its unique identifier.
		/// </summary>
		/// <param name="id">The unique identifier of the category to delete.</param>
		Task DeleteAsync(int id);
	}
}

