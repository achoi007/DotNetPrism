using StockAlert.Infra.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Events
{
    public class MarketSignalEvent : Microsoft.Practices.Prism.Events.CompositePresentationEvent<MarketSignal>
    {
    }
}
