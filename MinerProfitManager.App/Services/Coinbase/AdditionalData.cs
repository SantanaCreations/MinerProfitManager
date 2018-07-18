using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class AdditionalData
	{
		[JsonProperty("hash")]
		public string Hash { get; set; }

		[JsonProperty("amount")]
		public Amount Amount { get; set; }

		[JsonProperty("transaction")]
		public Resource Transaction { get; set; }
	}
}