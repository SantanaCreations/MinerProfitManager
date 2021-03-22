using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MinerProfitManager.App.Data;
using MinerProfitManager.App.Models;
using MinerProfitManager.App.Services;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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
			services.AddRazorPages();
			services.AddControllers().AddNewtonsoftJson(
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
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			NLog.GlobalDiagnosticsContext.Set(
				"DefaultConnection",
				Configuration.GetConnectionString(CONNECTION_STRING_NAME));

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapRazorPages();
			});
		}
	}
}