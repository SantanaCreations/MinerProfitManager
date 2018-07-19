using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Data;
using MinerProfitManager.App.Models;
using MinerProfitManager.App.Services;
using MinerProfitManager.App.Services.Coinbase;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using NLog.Extensions.Logging;
using NLog.Web;

// ReSharper disable UnusedMember.Global

namespace MinerProfitManager
{
	public class Startup
	{
		private const string CONNECTION_STRING_NAME = "AppContext";

		private IConfiguration Configuration { get; }

		public Startup(
			IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(
			IServiceCollection services)
		{
			// Add Database Configuration
			services.AddDbContext<AppDbContext>(
				options => options.UseSqlite(Configuration.GetConnectionString(CONNECTION_STRING_NAME)));

			// Add framework services
			services.AddMvc().AddJsonOptions(
				options =>
				{
					options.SerializerSettings.ContractResolver
						= new DefaultContractResolver();
					options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
					options.SerializerSettings.Converters.Add(new StringEnumConverter
					{
						AllowIntegerValues = false
					});
				});

			// Register application services.
			services.AddSingleton(Configuration.GetSection("App").Get<AppSettings>());

			// Register application services.
			services.AddScoped<IServiceNotificationRepository, ServiceNotificationRepository>();
			services.AddScoped<IServiceNotificationTransformer, ServiceNotificationTransformer>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory)
		{
			NLog.GlobalDiagnosticsContext.Set(
				"DefaultConnection",
				Configuration.GetConnectionString(CONNECTION_STRING_NAME));
			env.ConfigureNLog("log.config");

			loggerFactory.AddNLog();

			if (env.IsDevelopment())
			{
				loggerFactory.AddConsole();
				loggerFactory.AddDebug();
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	}
}