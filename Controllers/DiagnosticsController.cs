using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.ApplicationInsights;

namespace FenecApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiagnosticsController : ControllerBase
	{
		private readonly ILogger<DiagnosticsController> _logger;
		private readonly TelemetryClient _telemetry;
		private readonly IConfiguration _config;
		private readonly IHttpClientFactory _httpClientFactory;

		public DiagnosticsController(
			ILogger<DiagnosticsController> logger,
			TelemetryClient telemetry,
			IConfiguration config,
			IHttpClientFactory httpClientFactory)
		{
			_logger = logger;
			_telemetry = telemetry;
			_config = config;
			_httpClientFactory = httpClientFactory;
		}

		// 1) Logs all levels
		// GET /api/diagnostics/log-levels
		[HttpGet("log-levels")]
		public IActionResult LogAllLevels()
		{
			using (_logger.BeginScope(new Dictionary<string, object>
			{
				["CorrelationId"] = HttpContext.TraceIdentifier,
				["UserAgent"] = Request.Headers.UserAgent.ToString()
			}))
			{
				_logger.LogTrace("TRACE: diagnostic trace example");
				_logger.LogDebug("DEBUG: diagnostic debug example");
				_logger.LogInformation("INFO: user hit /log-levels at {Time}", DateTimeOffset.UtcNow);
				_logger.LogWarning("WARN: example warning with value {Value}", 123);
				_logger.LogError("ERROR: simulated error (no exception)");
				_logger.LogCritical("CRITICAL: simulated critical condition");
			}

			// Evento/metric custom en App Insights
			_telemetry.TrackEvent("Diag.LogLevels", new Dictionary<string, string>
			{
				["path"] = "/api/diagnostics/log-levels"
			});
			_telemetry.TrackMetric("Diag.CustomMetric", 1);

			return Ok("Logged all levels + custom event/metric.");
		}

		// 2) 400 Bad Request with validation error
		// GET /api/diagnostics/badrequest?value=
		[HttpGet("badrequest")]
		public IActionResult BadRequestSample([FromQuery] int? value)
		{
			if (value is null)
			{
				ModelState.AddModelError("value", "The 'value' query parameter is required.");
				_logger.LogWarning("BadRequest triggered due to missing 'value'");
				return ValidationProblem(ModelState);
			}
			return Ok(new { value });
		}

		// 3) 404 NotFound
		// GET /api/diagnostics/notfound
		[HttpGet("notfound")]
		public IActionResult NotFoundSample()
		{
			_logger.LogInformation("Returning 404 NotFound on purpose");
			return NotFound("This is a simulated 404.");
		}

		// 4) 403 Forbidden
		// GET /api/diagnostics/forbidden
		[HttpGet("forbidden")]
		public IActionResult ForbiddenSample()
		{
			_logger.LogWarning("Simulated forbidden");
			return Forbid();
		}

		// 5) 500 Internal Server Error (handled exception)
		// GET /api/diagnostics/handled-500
		[HttpGet("handled-500")]
		public IActionResult Handled500()
		{
			try
			{
				throw new InvalidOperationException("Simulated handled exception");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Handled exception caught");
				_telemetry.TrackException(ex, new Dictionary<string, string> { ["Handled"] = "true" });
				return StatusCode(500, "Handled 500 with logging.");
			}
		}

		// 6) 500 not handled (simulated unhandled exception)
		// GET /api/diagnostics/unhandled-500
		[HttpGet("unhandled-500")]
		public IActionResult Unhandled500()
		{
			_logger.LogInformation("About to throw unhandled exception");
			throw new ApplicationException("Simulated UNHANDLED exception"); // App Insights la captura
		}

		// 7) Slow request (simulate latency)
		// GET /api/diagnostics/slow?ms=3000
		[HttpGet("slow")]
		public async Task<IActionResult> Slow([FromQuery] int ms = 3000)
		{
			_logger.LogInformation("Simulating slow request for {ms} ms", ms);
			await Task.Delay(ms);
			return Ok(new { delayedMs = ms });
		}

		// 8) Simulate CPU burst for a specified number of seconds - Not recommended for production use
		// GET /api/diagnostics/cpu-burst?seconds=5
		[HttpGet("cpu-burst")]
		public IActionResult CpuBurst([FromQuery] int seconds = 5)
		{
			_logger.LogWarning("Starting CPU burst for {seconds} seconds", seconds);
			var end = DateTime.UtcNow.AddSeconds(seconds);
			// Busy loop para subir CPU
			while (DateTime.UtcNow < end) { _ = Math.Sqrt(12345.6789); }
			return Ok("CPU burst finished");
		}

		// 9) Http dependency OK (GET https://www.microsoft.com)
		// GET /api/diagnostics/http-ok
		[HttpGet("http-ok")]
		public async Task<IActionResult> HttpOk()
		{
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://www.microsoft.com");
			_logger.LogInformation("HTTP dep OK status {StatusCode}", res.StatusCode);
			return Ok($"HTTP OK: {(int)res.StatusCode}");
		}

		// 10) Failed HTTP dependency (GET https://nonexistent.example.invalid)
		// GET /api/diagnostics/http-fail
		[HttpGet("http-fail")]
		public async Task<IActionResult> HttpFail()
		{
			var client = _httpClientFactory.CreateClient();
			client.Timeout = TimeSpan.FromSeconds(3);
			try
			{
				// dominio inválido para provocar fallo
				var res = await client.GetAsync("https://nonexistent.example.invalid/");
				return Ok($"Unexpected success: {(int)res.StatusCode}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "HTTP dependency failed");
				_telemetry.TrackException(ex, new Dictionary<string, string> { ["Dependency"] = "HTTP" });
				return StatusCode(500, $"HTTP dependency failed: {ex.Message}");
			}
		}

		// 11) SQL OK (SELECT 1)
		// GET /api/diagnostics/sql-ok
		[HttpGet("sql-ok")]
		public async Task<IActionResult> SqlOk()
		{
			string? cs = _config.GetConnectionString("DefaultConnection");
			if (string.IsNullOrWhiteSpace(cs))
				return StatusCode(500, "Missing DefaultConnection");

			await using var conn = new SqlConnection(cs);
			await conn.OpenAsync();
			await using var cmd = new SqlCommand("SELECT 1", conn);
			var result = await cmd.ExecuteScalarAsync();
			_logger.LogInformation("SQL OK result: {Result}", result);
			return Ok(new { result });
		}

		// 12) SQL failed (SELECT from non-existent table)
		// GET /api/diagnostics/sql-fail
		[HttpGet("sql-fail")]
		public async Task<IActionResult> SqlFail()
		{
			string? cs = _config.GetConnectionString("DefaultConnection");
			if (string.IsNullOrWhiteSpace(cs))
				return StatusCode(500, "Missing DefaultConnection");

			try
			{
				await using var conn = new SqlConnection(cs);
				await conn.OpenAsync();
				await using var cmd = new SqlCommand("SELECT * FROM Table_That_Does_Not_Exist", conn);
				await cmd.ExecuteScalarAsync(); // provocará SqlException
				return Ok("Unexpected success");
			}
			catch (SqlException ex)
			{
				_logger.LogError(ex, "SQL dependency failed");
				_telemetry.TrackException(ex, new Dictionary<string, string> { ["Dependency"] = "SQL" });
				return StatusCode(500, $"SQL failed: {ex.Message}");
			}
		}

		// 13) Event and metric custom telemetry
		// GET /api/diagnostics/custom-telemetry
		[HttpGet("custom-telemetry")]
		public IActionResult CustomTelemetry()
		{
			var props = new Dictionary<string, string>
			{
				["Env"] = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown",
				["User"] = User?.Identity?.Name ?? "Anonymous"
			};

			_telemetry.TrackEvent("Diag.CustomEvent", props);
			_telemetry.TrackMetric("Diag.LatencyBudgetMs", 42);
			_logger.LogInformation("Custom telemetry sent");
			return Ok("Custom event/metric sent.");
		}
	}
}
