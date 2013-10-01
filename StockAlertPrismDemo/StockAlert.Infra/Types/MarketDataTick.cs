using StockAlert.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Types
{
    public class MarketDataTick
    {
        public string Symbol { get; set; }

        public decimal Last { get; set; }

        public decimal Ask { get; set; }

        public decimal Bid { get; set; }

        public decimal PreviousClose { get; set; }

        public decimal Change
        {
            get { return Last - PreviousClose; }
        }

        public long Volume { get; set; }

        public MarketDataTick Clone()
        {
            return new MarketDataTick()
            {
                Ask = this.Ask,
                Bid = this.Bid,
                Last = this.Last,
                PreviousClose = this.PreviousClose,
                Symbol = this.Symbol,
                Volume = this.Volume,
            };
        }
    }
}
