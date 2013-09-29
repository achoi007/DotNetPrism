using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Services
{
    public interface IHistoricalMarketDataService
    {
        string Name { get; }

        bool TryGetPrice(string symbol, DateTime fromDT, DateTime toDT, out HistoricalMarketDataTick tick);

        bool TryGetVolume(string symbol, DateTime fromDT, DateTime toDT, out HistoricalMarketDataTick tick);
    }
}
