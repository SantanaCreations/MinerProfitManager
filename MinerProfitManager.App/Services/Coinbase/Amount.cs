using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Amount
	{
		[JsonProperty("amount")]
		public decimal Value { get; set; }

		[JsonProperty("currency")]
		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyType Currency { get; set; }
	}
}