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
		private readonly ILogger<CategoriesController> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="CategoriesController"/> class.
		/// </summary>
		/// <param name="categoryService">The category service.</param>
		/// <param name="logger">The logger instance.</param>
		public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
		{
			_categoryService = categoryService;
			_logger = logger;
		}

		/// <summary>
		/// Retrieves a list of all categories.
		/// </summary>
		/// <returns>A list of categories.</returns>
		[HttpGet]
		[ProducesResponseType(typeof(List<CategoryDto>), 200)] // OK
		[ProducesResponseType(500)] // Internal Server Error
		public async Task<IActionResult> GetCategories()
		{
			_logger.LogInformation("Received request to get all categories.");

			var response = await _categoryService.GetAllCategoriesAsync();

			if (!response.IsSuccess)
			{
				_logger.LogWarning("Failed to retrieve categories: {ErrorMessage}", response.Message);
				return StatusCode(response.HttpCode, new { response.Message });
			}

			_logger.LogInformation("Successfully retrieved {Count} categories.", response.Data?.Count ?? 0);
			return Ok(response.Data);
		}

		/// <summary>
		/// Creates a new category.
		/// </summary>
		/// <param name="createCategoryDto">The DTO containing the category details.</param>
		/// <returns>The created category.</returns>
		[HttpPost]
		[ProducesResponseType(typeof(CategoryDto), 201)] // Created
		[ProducesResponseType(400)] // Bad Request
		[ProducesResponseType(500)] // Internal Server Error
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
		{
			_logger.LogInformation("Received request to create a new category: {CategoryName}", createCategoryDto.Name);

			var response = await _categoryService.CreateCategoryAsync(createCategoryDto);

			if (!response.IsSuccess)
			{
				_logger.LogWarning("Category creation failed: {ErrorMessage}", response.Message);
				return StatusCode(response.HttpCode, new { response.Message });
			}

			_logger.LogInformation("Category {CategoryId} created successfully.", response.Data?.Id);
			return CreatedAtAction(nameof(GetCategories), new { id = response.Data?.Id }, response.Data);
		}
	}
}
