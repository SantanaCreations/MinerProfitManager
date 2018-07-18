using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MinerProfitManager.App.Services.Coinbase;

using Newtonsoft.Json;

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

		public CoinbaseController(ILogger<CoinbaseController> logger)
		{
			_logger = logger;
		}

		// GET: hooks/<controller>
		[HttpGet]
		public StatusCodeResult Get()
		{
			_logger.LogDebug("GET request was recieved.");
			return ReturnStatusCode(HttpStatusCode.OK);
		}

		// POST hooks/<controller>
		[HttpPost]
		public StatusCodeResult Post(
			[FromBody] Notification notification)
		{
			if (notification == null)
			{
				return ReturnStatusCode(HttpStatusCode.OK);
			}

			var notificationString = JsonConvert.SerializeObject(notification);
			_logger.LogInformation(notificationString);

			return ReturnStatusCode(HttpStatusCode.OK);
		}

		private StatusCodeResult ReturnStatusCode(
			HttpStatusCode statusCode)
		{
			return StatusCode((int)statusCode);
		}
	}
}