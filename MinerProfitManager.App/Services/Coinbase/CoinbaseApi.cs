using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

using MinerProfitManager.App.Models;

using Newtonsoft.Json;

namespace MinerProfitManager.App.Services.Coinbase
{
	/// <summary>
	/// Interacts with the Coinbase API V2
	/// </summary>
	public class CoinbaseApi
	{
		private static byte[] _secretBytes;
		private static Encoding _encoding;

		private readonly string _applicationName;
		private readonly string _endpoint;
		private readonly string _token;

		/// <summary>
		/// Creates a new <see cref="CoinbaseApi"/>
		/// </summary>
		/// <param name="walletSettings">The settings to use to connect to Coinbase</param>
		public CoinbaseApi(
			WalletSettings walletSettings)
		{
			_endpoint = walletSettings.Endpoint;
			_token = walletSettings.Token;

			_encoding = Encoding.UTF8;
			_secretBytes = _encoding.GetBytes(walletSettings.Secret);
			_applicationName = Assembly.GetExecutingAssembly().GetName().Name;
		}

		public List<Wallet> GetWallets()
		{
			const string requestPath = "/accounts";
			using (var client = GetHttpClient(HttpMethod.Get, requestPath, null))
			{
				var response = client.GetAsync(requestPath).Result;

				if (!response.IsSuccessStatusCode)
				{
					return null;
				}

				var body = response.Content.ReadAsStringAsync().Result;
				var wallets = JsonConvert.DeserializeObject<List<Wallet>>(body);
				return wallets;
			}
		}

		private HttpClient GetHttpClient(
			HttpMethod method,
			string requestPath,
			string body)
		{
			var unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			var messageSignature = GetMessageSignature(unixTime, method, requestPath, body);

			var client = new HttpClient {BaseAddress = new Uri($"{_endpoint.TrimEnd('/')}")};
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("User-Agent", _applicationName);
			client.DefaultRequestHeaders.Add("CB-ACCESS-KEY", _token);
			client.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", messageSignature);
			client.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", unixTime.ToString());
			return client;
		}

		private static string GetMessageSignature(
			long timestamp,
			HttpMethod method,
			string requestPath,
			string body)
		{
			using (var hasher = new HMACSHA256(_secretBytes))
			{
				var messageString = $"{timestamp}{method.Method}{requestPath}{body}";
				var messageBytes = _encoding.GetBytes(messageString);
				var hashBytes = hasher.ComputeHash(messageBytes);
				return _encoding.GetString(hashBytes);

			}
		}
	}
}