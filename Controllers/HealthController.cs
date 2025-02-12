using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FenecApi.Controllers
{
	/// <summary>
	/// Controller for monitoring application health.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class HealthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<HealthController> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="HealthController"/> class.
		/// </summary>
		/// <param name="configuration">The application configuration settings.</param>
		/// <param name="logger">The logger instance for logging events.</param>
		public HealthController(IConfiguration configuration, ILogger<HealthController> logger)
		{
			_configuration = configuration;
			_logger = logger;
		}

		/// <summary>
		/// Checks the connection to the configured database.
		/// </summary>
		/// <returns>A response indicating whether the database connection is successful.</returns>
		[HttpGet("db-connection")]
		[ProducesResponseType(200)] // OK
		[ProducesResponseType(500)] // Internal Server Error
		public async Task<IActionResult> CheckDatabaseConnection()
		{
			_logger.LogInformation("Checking database connection...");

			var connectionString = _configuration.GetConnectionString("DefaultConnection");

			if (string.IsNullOrWhiteSpace(connectionString))
			{
				_logger.LogError("Database connection string is missing or empty.");
				return StatusCode(500, "Database connection string is not configured.");
			}

			try
			{
				await using var connection = new SqlConnection(connectionString);
				await connection.OpenAsync();

				if (connection.State == ConnectionState.Open)
				{
					_logger.LogInformation("Successfully connected to the database.");
					return Ok("Connection to the database is successful.");
				}

				_logger.LogError("Database connection opened but state is not 'Open'.");
				return StatusCode(500, "Database connection established but not in an open state.");
			}
			catch (SqlException sqlEx)
			{
				_logger.LogError(sqlEx, "Database connection failed due to SQL error.");
				return StatusCode(500, $"Database connection failed: {sqlEx.Message}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Database connection failed due to an unexpected error.");
				return StatusCode(500, $"Unexpected error occurred: {ex.Message}");
			}
		}
	}
}
