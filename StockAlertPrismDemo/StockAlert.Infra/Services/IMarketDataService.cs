using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Services
{
    public interface IMarketDataService
    {
        string Name { get; }

        /// <summary>
        /// Ask market data to start publishing market data for given symbol.  Dispose returned object to unsubscribe.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>subscription disposable</returns>
        IDisposable Subscribe(string symbol);

        /// <summary>
        /// Try to get current tick for given symbol.  May return null if symbol has never been subscribed to.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="tick"></param>
        /// <returns></returns>
        bool TryGetTick(string symbol, out MarketDataTick tick);
    }
}
