using MinerProfitManager.App.Models;
using MinerProfitManager.App.Services.Coinbase;

namespace MinerProfitManager.App.Services
{
	/// <summary>
	/// Interface for creating a transformer for <see cref="ServiceNotification"/>.
	/// </summary>
	public interface IServiceNotificationTransformer
	{
		/// <summary>
		/// Transforms a <see cref="ServiceNotification"/> from a <see cref="CoinbaseNotification"/>.
		/// </summary>
		/// <param name="coinbaseNotification">The <see cref="CoinbaseNotification"/> to transform.</param>
		/// <returns>A <see cref="ServiceNotification"/> with the relevant information available in the <see cref="CoinbaseNotification"/>.</returns>
		ServiceNotification FromNotification(
			CoinbaseNotification coinbaseNotification);
	}
}