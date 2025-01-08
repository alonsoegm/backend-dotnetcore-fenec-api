namespace FenecApi.Extensions
{
	public static class MiddlewareExtensions
	{
		public static void ConfigureMiddlewares(this IApplicationBuilder app)
		{
			// Example: Add custom middleware here
			app.UseHttpsRedirection();
			app.UseAuthorization();
		}
	}
}
