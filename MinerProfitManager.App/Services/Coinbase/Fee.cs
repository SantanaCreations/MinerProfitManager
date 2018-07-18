using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Fee
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("amount")]
		public Amount Amount { get; set; }
	}
}