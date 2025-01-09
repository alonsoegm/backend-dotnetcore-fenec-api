using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace FenecApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public HealthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpGet("db-connection")]
		public IActionResult CheckDatabaseConnection()
		{
			try
			{
				var connectionString = _configuration.GetConnectionString("DefaultConnection");
				using var connection = new SqlConnection(connectionString);
				connection.Open();

				return Ok("Connection to the database is successful.");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Database connection failed: {ex.Message}");
			}
		}
	}
}
