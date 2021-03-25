using System.Collections.Generic;

namespace MinerProfitManager.App.Services.NiceHash
{
    public class ServerInfo
    {
        public string ServerTime { get; set; }
    }

    public class CurrenciesCollection
    {
        public List<Coin> Currencies { get; set; }
    }

    public class Coin
    {
        public string Currency { get; set; }

        public double Available { get; set; }
    }

    public class SymbolsCollection
    {
        public List<Symbol> Symbols { get; set; }
    }

    public class Symbol
    {
        public string BaseAsset { get; set; }
    }
}