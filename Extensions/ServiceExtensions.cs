using Microsoft.EntityFrameworkCore;
using FenecApi.Data;

namespace FenecApi.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FenecDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		}
	}
}
