using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Data;

using NLog.Web;

namespace MinerProfitManager
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var context = services.GetRequiredService<AppDbContext>();
					var databaseExists = context.Database.EnsureCreatedAsync().Result;

					if (!databaseExists)
					{
						var logger = services.GetRequiredService<ILogger<Program>>();
						logger.LogError("Database could not be created.");
					}
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred seeding the DB.");
				}
				finally
				{
					// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
					NLog.LogManager.Shutdown();
				}
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(
			string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				})
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
				})
				.UseNLog();
	}
}