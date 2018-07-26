namespace MinerProfitManager.App.Models
{
	/// <summary>
	/// Represents the application configuration settings
	/// </summary>
	public class AppSettings
	{
		/// <summary>
		/// Whether or not the application is on debug mode.
		/// </summary>
		public bool DebugMode { get; set; }

		/// <summary>
		/// The settings to use to connect to the wallet service API
		/// </summary>

		public WalletSettings WalletSettings { get; set; }
	}
}