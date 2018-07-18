using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	public class Data
	{
		[Key]
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("status")]
		public ResourceStatus Status { get; set; }

		[JsonProperty("payment_method")]
		public Resource PaymentMethod { get; set; }

		[JsonProperty("transaction")]
		public Resource Transaction { get; set; }

		[JsonProperty("user_reference")]
		public string UserReference { get; set; }

		[DataType(DataType.DateTime)]
		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[DataType(DataType.DateTime)]
		[JsonProperty("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty("resource")]
		public ResourceType Resource { get; set; }

		[JsonProperty("resource_path")]
		public string ResourcePath { get; set; }

		[JsonProperty("committed")]
		public bool Committed { get; set; }

		[DataType(DataType.DateTime)]
		[JsonProperty("payout_at")]
		public DateTime PayoutAt { get; set; }

		[JsonProperty("fee")]
		public Amount Fee { get; set; }

		[JsonProperty("amount")]
		public Amount Amount { get; set; }

		[JsonProperty("subtotal")]
		public Amount Subtotal { get; set; }

		[JsonProperty("idem")]
		public Guid Idem { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("total")]
		public Amount Total { get; set; }

		[JsonProperty("instant")]
		public bool Instant { get; set; }

		[JsonProperty("fees")]
		public List<Fee> Fees { get; set; }
	}
}