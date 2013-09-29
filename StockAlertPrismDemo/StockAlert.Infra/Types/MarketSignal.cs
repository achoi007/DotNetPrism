using StockAlert.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Types
{
    public class MarketSignal
    {
        /// <summary>
        /// Symbol for which signal applies.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Human readable message of signal
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 0 to 100.  100 indicates very intense, 0 indicates very weak.
        /// </summary>
        public int Intensity { get; set; }

        /// <summary>
        /// order side of signal.  Is it signal to buy, signal to sell, etc.
        /// </summary>
        public Side Side { get; set; }

        /// <summary>
        /// Name of signal
        /// </summary>
        public string Name { get; set; }
    }
}
