using MinerProfitManager.App.Configuration;
using MinerProfitManager.App.Services.NiceHash;

namespace MinerProfitManager.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NlogLogger.ConfigureNLog();

            var nicehashApi = new NiceHashApi();
            nicehashApi.Test();
        }
    }
}
