using System.Net;
using System.Text.Json;

namespace FenecApi.Middlewares;
/// <summary>
/// Middleware that handles all uncaught exceptions globally and logs them.
/// </summary>
public class ExceptionHandlingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context); // Continue processing request
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An unhandled exception occurred.");
			await HandleExceptionAsync(context, ex);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		var response = new
		{
			Message = "An unexpected error occurred.",
			Error = exception.Message
		};

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		return context.Response.WriteAsync(JsonSerializer.Serialize(response));
	}
}
