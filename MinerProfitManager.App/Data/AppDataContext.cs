﻿using Microsoft.EntityFrameworkCore;

using MinerProfitManager.App.Models;

namespace MinerProfitManager.App.Data
{
	/// <summary>
	/// Represents the database context for the application.
	/// </summary>
	public class AppDbContext : DbContext
	{
		/// <summary>
		/// Creates a new <see cref="AppDbContext"/>
		/// </summary>
		/// <param name="options">The options provided to the context for configuration.</param>
		public AppDbContext(
			DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		/// <summary>
		/// The collection of <see cref="Log"/> entities.
		/// </summary>
		public DbSet<Log> Log { get; set; }
	}
}