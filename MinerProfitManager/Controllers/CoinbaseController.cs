using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Data;
using MinerProfitManager.App.Services;
using MinerProfitManager.App.Services.Coinbase;

namespace MinerProfitManager.Controllers
{
	/// <summary>
	/// A controller for Coinbase notifications
	/// </summary>
	[Produces("application/json")]
	[Route("hooks/[controller]")]
	public class CoinbaseController : ControllerBase
	{
		private readonly ILogger<CoinbaseController> _logger;
		private readonly IServiceNotificationRepository _repository;
		private readonly IServiceNotificationTransformer _transformer;

		public CoinbaseController(
			ILogger<CoinbaseController> logger,
			IServiceNotificationRepository repository,
			IServiceNotificationTransformer transformer)
		{
			_logger = logger;
			_repository = repository;
			_transformer = transformer;
		}

		// GET: hooks/<controller>
		[HttpGet]
		public StatusCodeResult Get()
		{
			_logger.LogDebug("GET request was received.");
			return ReturnStatusCode(HttpStatusCode.OK);
		}

		// POST hooks/<controller>
		[HttpPost]
		public StatusCodeResult Post(
			[FromBody] CoinbaseNotification coinbaseNotification)
		{
			if (coinbaseNotification == null)
			{
				_logger.LogError(ToDebugString(ModelState));
				_logger.LogWarning("POST request was null.");
				return ReturnStatusCode(HttpStatusCode.BadRequest);
			}

			var savedCoinbaseNotification = _repository.Get(coinbaseNotification.Id.ToString());
			if (savedCoinbaseNotification != null)
			{
				return ReturnStatusCode(HttpStatusCode.OK);
			}

			var notification = _transformer.FromNotification(coinbaseNotification);
			_repository.Add(notification);

			return ReturnStatusCode(HttpStatusCode.OK);
		}

		private StatusCodeResult ReturnStatusCode(
			HttpStatusCode statusCode)
		{
			return StatusCode((int)statusCode);
		}

		private static string ToDebugString<TKey, TValue>(
			IReadOnlyDictionary<TKey, TValue> dictionary)
		{
			return "{" + string.Join(",", dictionary.Select(kv => kv.Key).ToArray()) + "}";
		}
	}
}