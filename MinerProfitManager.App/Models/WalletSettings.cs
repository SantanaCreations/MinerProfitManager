namespace MinerProfitManager.App.Models
{
	/// <summary>
	/// Settings for the wallet service
	/// </summary>
	public class WalletSettings
	{
		/// <summary>
		/// The endpoint to use to connect to the wallet
		/// </summary>
		public string Endpoint { get; set; }

		/// <summary>
		/// The token for API authentication
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// The secret for API authentication
		/// </summary>
		public string Secret { get; set; }
	}
}