using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Data.Extensions;

namespace Vacations.Services.Extensions
{
	public static class DatabaseLoaderExtension
	{
		public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString;
			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "production")
			{
				var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB_NAME");
				var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
				var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");

				if (dbName != null && dbUser != null && dbPassword != null)
					connectionString = $"Host=database;Database={dbName};Username={dbUser};Password={dbPassword}";
				else
					throw new Exception("Не задана конфигурация БД");
			}
			else
				connectionString = configuration.GetConnectionString("default");

			services.AddDatabase(connectionString);
		}
	}
}
