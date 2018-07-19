using System;
using System.Collections.Generic;

using MinerProfitManager.App.Models;

namespace MinerProfitManager.App.Data
{
	/// <summary>
	/// Interface for creating a <see cref="ServiceNotification"/> repository.
	/// </summary>
	public interface IServiceNotificationRepository : IDisposable
	{
		/// <summary>
		///	Lists all of the available notifications.
		/// </summary>
		/// <returns>A <see cref="List{T}"/> of all of the available <see cref="ServiceNotification"/>.</returns>
		List<ServiceNotification> ListAll();

		/// <summary>
		/// Gets a <see cref="ServiceNotification"/> by the given notification ID.
		/// </summary>
		/// <param name="id">The unique database identifier of the notification to get.</param>
		/// <returns>A <see cref="ServiceNotification"/> if it was found, null otherwise.</returns>
		ServiceNotification Get(
			string id);

		/// <summary>
		/// Adds the given <see cref="ServiceNotification"/> to the repository.
		/// </summary>
		/// <param name="notification">The <see cref="ServiceNotification"/> to add.</param>
		/// <returns>True if the operation was successful, False otherwise.</returns>
		bool Add(
			ServiceNotification notification);

		/// <summary>
		/// Updates the given <see cref="ServiceNotification"/> in the repository.
		/// </summary>
		/// <param name="notification">The <see cref="ServiceNotification"/> to update.</param>
		/// <returns>True if the operation was successful, False otherwise.</returns>
		bool Update(
			ServiceNotification notification);

		/// <summary>
		/// Removes the given <see cref="ServiceNotification"/> from the repository.
		/// </summary>
		/// <param name="notification">The <see cref="ServiceNotification"/> to remove.</param>
		/// <returns>True if the operation was successful, False otherwise.</returns>
		bool Remove(
			ServiceNotification notification);
	}
}