using FenecApi.DTOs.utils;
using FenecApi.DTOs;

namespace FenecApi.Services.Interfaces
{
	public interface ICategoryService
	{
		/// <summary>
		/// Retrieves all categories from the database.
		/// </summary>
		/// <returns>A ServiceResponse containing a list of CategoryDto objects.</returns>
		Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();

		/// <summary>
		/// Creates a new category in the database.
		/// </summary>
		/// <param name="createCategoryDto">The DTO containing the category details.</param>
		/// <returns>A ServiceResponse containing the created CategoryDto object.</returns>
		Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
	}
}
