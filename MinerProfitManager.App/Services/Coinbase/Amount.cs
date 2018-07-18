using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Amount
	{
		[JsonProperty("amount")]
		public decimal Value { get; set; }

		[JsonProperty("currency")]
		public CurrencyType Currency { get; set; }
	}
}