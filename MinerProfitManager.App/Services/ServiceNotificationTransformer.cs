using MinerProfitManager.App.Models;
using MinerProfitManager.App.Services.Coinbase;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services
{
	/// <summary>
	/// Transformer for <see cref="ServiceNotification"/>
	/// </summary>
	public class ServiceNotificationTransformer : IServiceNotificationTransformer
	{
		/// <inheritdoc cref="IServiceNotificationTransformer.FromNotification"/>
		public ServiceNotification FromNotification(
			CoinbaseNotification coinbaseNotification)
		{
			return new ServiceNotification
			{
				Id = coinbaseNotification.Id.ToString(),
				Type = coinbaseNotification.Type,
				Resource = coinbaseNotification.Resource,
				AccountId = coinbaseNotification.Account?.Id.ToString(),
				UserId = coinbaseNotification.User?.Id.ToString(),
				TransactionId = coinbaseNotification.Data?.Transaction?.Id.ToString(),
				Address = coinbaseNotification.Data?.Address,
				CreatedAt = coinbaseNotification.CreatedAt,
				DeliveryAttempts = coinbaseNotification.DeliveryAttempts,
				Payload = JsonConvert.SerializeObject(coinbaseNotification)
			};
		}
	}
}