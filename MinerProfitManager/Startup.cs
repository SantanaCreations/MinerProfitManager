using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Data;
using MinerProfitManager.App.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MinerProfitManager
{
	public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add Database Configuration
			services.AddDbContext<AppDbContext>(
				options => options.UseSqlite(Configuration.GetConnectionString("AppContext")));

			// Add framework services
			services.AddMvc().AddJsonOptions(
				options =>
				{
					options.SerializerSettings.ContractResolver
						= new DefaultContractResolver();
					options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
				}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			// Register application services.
			services.AddSingleton(Configuration.GetSection("App").Get<AppSettings>());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
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