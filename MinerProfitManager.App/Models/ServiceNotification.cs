using System;
using System.ComponentModel.DataAnnotations;

using MinerProfitManager.App.Services.Coinbase;

namespace MinerProfitManager.App.Models
{
	/// <summary>
	/// Represents a notification created by a third party service.
	/// </summary>
	public class ServiceNotification
	{
		[Key]
		public string Id { get; set; }

		public string Type { get; set; }

		public ResourceType Resource { get; set; }

		public string AccountId { get; set; }

		public string UserId { get; set; }

		public string TransactionId { get; set; }

		public string Address { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreatedAt { get; set; }

		public int DeliveryAttempts { get; set; }

		public string Payload { get; set; }
	}
}