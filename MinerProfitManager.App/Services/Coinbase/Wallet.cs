using System;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Wallet
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("primary")]
		public bool Primary { get; set; }

		[JsonProperty("type")]
		public WalletType Type { get; set; }

		[JsonProperty("currency")]
		public CurrencyType Currency { get; set; }

		[JsonProperty("balance")]
		public Balance Balance { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("resource")]
		public ResourceType Resource { get; set; }

		[JsonProperty("resource_path")]
		public string ResourcePath { get; set; }
	}
}