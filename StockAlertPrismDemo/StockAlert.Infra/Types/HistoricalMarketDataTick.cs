using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Types
{
    public class HistoricalMarketDataTick
    {
        public string Symbol { get; set; }

        public decimal Average { get; set; }

        public decimal StdDev { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Message { get; set; }
    }
}
