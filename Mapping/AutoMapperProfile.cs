using AutoMapper;
using FenecApi.DTOs;
using FenecApi.Models;

namespace FenecApi.Mapping
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// Category Mappings
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();

			// Product Mappings (Example for later)
			// CreateMap<Product, ProductDto>().ReverseMap();
		}
	}
}
