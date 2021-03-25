using NLog;
using NLog.Config;
using NLog.Targets;

namespace MinerProfitManager.App.Configuration
{
	public static class NlogLogger
	{
		public static void ConfigureNLog()
		{
			var config = new LoggingConfiguration();
			var logconsole = new ConsoleTarget("logconsole");
			config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
			LogManager.Configuration = config;
		}

		public static Logger GetLogger()
		{
			 return LogManager.GetCurrentClassLogger();
		}
	}
}
