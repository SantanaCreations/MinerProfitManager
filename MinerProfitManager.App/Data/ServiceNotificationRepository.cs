using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using MinerProfitManager.App.Models;

namespace MinerProfitManager.App.Data
{
	/// <summary>
	/// A repository for <see cref="ServiceNotification"/> entities.
	/// </summary>
	public class ServiceNotificationRepository : IServiceNotificationRepository
	{
		private readonly AppDbContext _context;

		/// <summary>
		/// Creates a new <see cref="ServiceNotificationRepository"/>
		/// </summary>
		/// <param name="context">The database context to use for managing the data.</param>
		public ServiceNotificationRepository(
			AppDbContext context)
		{
			_context = context;
		}

		/// <inheritdoc cref="ServiceNotificationRepository.ListAll"/>
		public List<ServiceNotification> ListAll()
		{
			return _context.ServiceNotification.ToListAsync().Result;
		}

		/// <inheritdoc cref="ServiceNotificationRepository.Get"/>
		public ServiceNotification Get(
			string id)
		{
			return _context.ServiceNotification.FindAsync(id).Result;
		}

		/// <inheritdoc cref="ServiceNotificationRepository.Add"/>
		public bool Add(
			ServiceNotification notification)
		{
			_context.ServiceNotification.AddAsync(notification);
			return _context.SaveChangesAsync().Result > 0;
		}

		/// <inheritdoc cref="ServiceNotificationRepository.Update"/>
		public bool Update(
			ServiceNotification notification)
		{
			var existingSite = Get(notification.Id.ToString());

			if (existingSite == null)
			{
				return false;
			}

			_context.ServiceNotification.Update(existingSite);
			return _context.SaveChangesAsync().Result > 0;
		}

		/// <inheritdoc cref="ServiceNotificationRepository.Remove"/>
		public bool Remove(
			ServiceNotification notification)
		{
			if (notification == null)
			{
				return false;
			}

			_context.Remove(notification);
			return _context.SaveChangesAsync().Result > 0;
		}

		/// <inheritdoc cref="IDisposable.Dispose"/>
		public void Dispose()
		{
			_context.Dispose();
		}
	}
}