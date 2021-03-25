using MinerProfitManager.App.Configuration;
using Newtonsoft.Json;
using NLog;
using System.Data;

namespace MinerProfitManager.App.Services.NiceHash
{
	public class NiceHashApi
    {
        private static string ALGORITHM = "DAGGERHASHIMOTO";

        private static Logger Logger = NlogLogger.GetLogger();
        
        private readonly ApiSettings _apiSettings;
        private readonly NiceHashClient _nicehashClient;

        public NiceHashApi()
        {
            _apiSettings = new ApiSettings();
            _nicehashClient = new NiceHashClient(_apiSettings);
        }

        public void Test()
        {
            //get server time
            string timeResponse = _nicehashClient.Get("/api/v2/time");
            ServerInfo serverTimeObject = JsonConvert.DeserializeObject<ServerInfo>(timeResponse);
            string time = serverTimeObject.ServerTime;
            Logger.Info("server time: {}", time);

            //get algo settings
            string algosResponse = _nicehashClient.Get("/main/api/v2/mining/algorithms");
            DataSet algoObject = JsonConvert.DeserializeObject<DataSet>(algosResponse);
            DataTable algoTable = algoObject.Tables["miningAlgorithms"];

            DataRow mySettings = null;
            foreach (DataRow algo in algoTable.Rows)
            {
                if (algo["algorithm"].Equals(ALGORITHM))
                {
                    mySettings = algo;
                }
            }
            Logger.Info("algo settings: {}", mySettings["algorithm"]);

            //get balance
            string accountsResponse = _nicehashClient.Get("/main/api/v2/accounting/accounts2", true, time);
            CurrenciesCollection currenciesObj = JsonConvert.DeserializeObject<CurrenciesCollection>(accountsResponse);
            double myBalace = 0;
            foreach (Coin c in currenciesObj.Currencies)
            {
                if (c.Currency.Equals(_apiSettings.DefaultCurrency))
                {
                    myBalace = c.Available;
                }
            }
            Logger.Info("balance: {} {}", myBalace, _apiSettings.DefaultCurrency);
        }
    }
}
