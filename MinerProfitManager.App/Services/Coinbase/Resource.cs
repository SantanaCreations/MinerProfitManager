using System;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Resource
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("resource")]
		public ResourceType Type { get; set; }

		[JsonProperty("resource_path")]
		public string ResourcePath { get; set; }
	}
}