using MinerProfitManager.App.Services.Coinbase;

using Xunit;

namespace MinerProfitManager.App.Test.Services.Coinbase
{
	public class CoinbaseApiTests : TestBase
	{
		private readonly CoinbaseApi _api;

		public CoinbaseApiTests()
		{
			_api = new CoinbaseApi(AppSettings.WalletSettings);
		}

		[Fact]
		public void GetWallets_Test()
		{
			var wallets = _api.GetWallets();

			Assert.NotNull(wallets);
		}
	}
}