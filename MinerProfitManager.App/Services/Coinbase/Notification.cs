using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Notification
	{
		[Key]
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("data")]
		public Data Data { get; set; }

		[JsonProperty("user")]
		public Resource User { get; set; }

		[JsonProperty("account")]
		public Resource Account { get; set; }

		[JsonProperty("delivery_attempts")]
		public int DeliveryAttempts { get; set; }

		[DataType(DataType.DateTime)]
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("resource")]
		public ResourceType Resource { get; set; }

		[JsonProperty("resource_path")]
		public string ResourcePath { get; set; }

		[JsonProperty("additional_data")]
		public AdditionalData AdditionalData { get; set; }
	}
}