using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Types
{
    public enum Side
    {
        Buy,
        Sell,
        SellShort,
        BuyToCover,
    }

    public enum PriceType
    {
        Market,
        Limit,
        Stop,
        StopLimit,
    }
}
