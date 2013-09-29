using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Services
{
    public interface IMarketSignalService
    {
        string Name { get; }

        /// <summary>
        /// Ask service to start generating market signals for given symbol.  Dispose returned value to dispose
        /// market signal generation.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        IDisposable Subscribe(string symbol);

        /// <summary>
        /// Try to get market signal for given symbol.  May return null if market signal has never been subscribed to before.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="signal"></param>
        /// <returns></returns>
        bool TryGetSignal(string symbol, out MarketSignal signal);
    }
}
