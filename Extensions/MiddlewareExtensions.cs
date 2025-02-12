using FenecApi.Middlewares;

namespace FenecApi.Extensions
{
	public static class MiddlewareExtensions
	{
		public static void ConfigureMiddlewares(this IApplicationBuilder app)
		{
			
			app.UseHttpsRedirection();
			app.UseAuthorization();

			// Example: Add custom middleware here

			// Exception handling middleware
			app.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
