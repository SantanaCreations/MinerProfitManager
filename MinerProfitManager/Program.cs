using System;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Data;

using NLog.Web;

namespace MinerProfitManager
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);

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

		private static IWebHost BuildWebHost(
			string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
				})
				.UseNLog()
				.Build();
	}
}