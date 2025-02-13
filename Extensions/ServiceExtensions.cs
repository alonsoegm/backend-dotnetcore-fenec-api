﻿using Microsoft.EntityFrameworkCore;
using FenecApi.Data;
using NLog;

namespace FenecApi.Extensions;

/// <summary>
/// Extension methods for configuring services.
/// </summary>
public static class ServiceExtensions
{

	public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

		var connectionString = configuration.GetConnectionString("DefaultConnection")
				 ?? Environment.GetEnvironmentVariable("DefaultConnection");

		services.AddDbContext<FenecDbContext>(options =>
			options.UseSqlServer(connectionString));
	}
}

