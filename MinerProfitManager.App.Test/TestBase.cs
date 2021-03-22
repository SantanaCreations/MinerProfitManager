﻿using System;

using Microsoft.Extensions.Configuration;

using MinerProfitManager.App.Models;

namespace MinerProfitManager.App.Test
{
	public abstract class TestBase
	{
		private const string APP_SETTINGS = "appsettings.test.json";

		protected AppSettings AppSettings { get; }

		protected TestBase()
		{
			AppSettings = GetAppSettings();

			if (AppSettings == null)
			{
				throw new Exception("AppSettings could not be loaded.");
			}
		}

		private static AppSettings GetAppSettings()
		{
			return new ConfigurationBuilder()
				//.AddUserSecrets<AppSettings>()
				.AddJsonFile(APP_SETTINGS)
				.Build().Get<AppSettings>();
		}
	}
}