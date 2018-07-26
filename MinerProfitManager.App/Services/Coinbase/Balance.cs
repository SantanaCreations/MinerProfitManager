using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Balance
	{
		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[JsonProperty("currency")]
		public CurrencyType Currency { get; set; }
	}
}