using AutoMapper;
using FenecApi.DTOs.utils;
using FenecApi.DTOs;
using FenecApi.Models;
using FenecApi.Services.Interfaces;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Services;
/// <summary>
/// Service responsible for handling business logic related to categories.
/// </summary>
public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;
	private readonly ILogger<CategoryService> _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="CategoryService"/> class.
	/// </summary>
	/// <param name="categoryRepository">The category repository.</param>
	/// <param name="mapper">The AutoMapper instance for mapping objects.</param>
	/// <param name="logger">The logger instance for logging events.</param>
	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILogger<CategoryService> logger)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
		_logger = logger;
	}

	/// <inheritdoc />
	public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
	{
		_logger.LogInformation("Fetching all categories from the database.");

		var categories = await _categoryRepository.GetAllAsync();
		var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

		_logger.LogInformation("Successfully retrieved {CategoryCount} categories.", categories.Count);
		return new ServiceResponse<List<CategoryDto>> { Data = categoriesDto };
	}

	/// <inheritdoc />
	public async Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
	{
		_logger.LogInformation("Creating a new category: {CategoryName}", createCategoryDto.Name);

		var category = _mapper.Map<Category>(createCategoryDto);
		await _categoryRepository.AddAsync(category);

		var categoryDto = _mapper.Map<CategoryDto>(category);
		_logger.LogInformation("Category {CategoryId} created successfully.", category.Id);
		return new ServiceResponse<CategoryDto> { Data = categoryDto };
	}
}
