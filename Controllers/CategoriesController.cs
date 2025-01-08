using FenecApi.DTOs;
using FenecApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FenecApi.Controllers
{
	/// <summary>
	/// API Controller for managing categories.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		/// <summary>
		/// Retrieves a list of all categories.
		/// </summary>
		/// <returns>An IActionResult containing the list of categories.</returns>
		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var response = await _categoryService.GetAllCategoriesAsync();
			return StatusCode(response.HttpCode, response);
		}

		/// <summary>
		/// Creates a new category.
		/// </summary>
		/// <param name="createCategoryDto">The DTO containing the category details.</param>
		/// <returns>An IActionResult containing the created category.</returns>
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var response = await _categoryService.CreateCategoryAsync(createCategoryDto);
			return StatusCode(response.HttpCode, response);
		}
	}
}
