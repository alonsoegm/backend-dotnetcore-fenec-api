using AutoMapper;
using FenecApi.DTOs.utils;
using FenecApi.DTOs;
using FenecApi.Models;
using FenecApi.Services.Interfaces;
using FenecApi.Repositories.Interfaces;

namespace FenecApi.Services
{
	/// <summary>
	/// Service responsible for handling business logic related to categories.
	/// </summary>
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		/// <inheritdoc />
		public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategoriesAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();
			var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

			return new ServiceResponse<List<CategoryDto>> { Data = categoriesDto };
		}

		/// <inheritdoc />
		public async Task<ServiceResponse<CategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
		{
			var category = _mapper.Map<Category>(createCategoryDto);
			await _categoryRepository.AddAsync(category);

			var categoryDto = _mapper.Map<CategoryDto>(category);
			return new ServiceResponse<CategoryDto> { Data = categoryDto };
		}
	}
}
