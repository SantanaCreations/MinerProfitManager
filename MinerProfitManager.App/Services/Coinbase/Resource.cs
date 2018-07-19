using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Resource
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("resource")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ResourceType Type { get; set; }

		[JsonProperty("resource_path")]
		public string ResourcePath { get; set; }
	}
}