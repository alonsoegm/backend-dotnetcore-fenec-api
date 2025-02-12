using FenecApi.Repositories.Interfaces;
using FenecApi.Repositories;
using FenecApi.Services.Interfaces;
using FenecApi.Services;

namespace FenecApi.Extensions;

/// <summary>
/// Extension methods for dependency injection configuration.
/// </summary>
public static class DependencyInjectionExtensions
{
	public static void ConfigureDependencies(this IServiceCollection services)
	{
		// Example: Add your services and repositories here

		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICategoryService, CategoryService>();


	}
}
