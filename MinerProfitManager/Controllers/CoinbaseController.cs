using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

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
		public JObject Get()
		{
			_logger.LogInformation($"GET request was performed in {GetType().Name}");
			return new JObject();
		}

		// POST hooks/<controller>
		[HttpPost]
		public JObject Post(
			[FromBody] string notification)
		{
			_logger.LogInformation(notification);
			return new JObject();
		}

		private StatusCodeResult ReturnStatusCode(
			HttpStatusCode statusCode)
		{
			return StatusCode((int)statusCode);
		}
	}
}