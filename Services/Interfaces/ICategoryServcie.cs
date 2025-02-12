using FenecApi.DTOs.utils;
using FenecApi.DTOs;

namespace FenecApi.Services.Interfaces;
/// <summary>
/// Interface that defines business logic operations for categories.
/// </summary>
public interface ICategoryService
{
	/// <summary>
	/// Retrieves all categories from the database.
	/// </summary>
	/// <returns>
	/// A <see cref="ServiceResponse{T}"/> containing a list of <see cref="CategoryDto"/> objects.
	/// </returns>
	Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync();

	/// <summary>
	/// Creates a new category in the database.
	/// </summary>
	/// <param name="createCategoryDto">
	/// The DTO containing the details of the category to be created.
	/// </param>
	/// <returns>
	/// A <see cref="ServiceResponse{T}"/> containing the created <see cref="CategoryDto"/> object.
	/// </returns>
	Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
}
