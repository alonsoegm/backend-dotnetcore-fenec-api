using Microsoft.EntityFrameworkCore;
using FenecApi.Data;

namespace FenecApi.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection")
					 ?? Environment.GetEnvironmentVariable("DefaultConnection");

			services.AddDbContext<FenecDbContext>(options =>
				options.UseSqlServer(connectionString));
		}
	}
}
