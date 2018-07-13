using System.Net;

using Microsoft.AspNetCore.Mvc;

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
		// GET: hooks/<controller>
		[HttpGet]
		public JObject Get()
		{
			return new JObject();
		}

		// POST hooks/<controller>
		[HttpPost]
		public JObject Post(
			[FromBody] string notification)
		{
			return new JObject();
		}

		private StatusCodeResult ReturnStatusCode(
			HttpStatusCode statusCode)
		{
			return StatusCode((int)statusCode);
		}
	}
}