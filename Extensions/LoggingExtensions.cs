using NLog.Web;

namespace FenecApi.Extensions;
/// <summary>
/// Extension methods for logging configuration.
/// </summary>
public static class LoggingExtensions
{
	/// <summary>
	/// Configures NLog as the logging provider.
	/// </summary>
	/// <param name="builder">The web application builder.</param>
	public static void ConfigureLogging(this WebApplicationBuilder builder)
	{
		// Load NLog configuration from nlog.config
		builder.Logging.ClearProviders();  // Remove default logging providers
		builder.Host.UseNLog(); // Set NLog as the logging provider
	}
}
