using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using StockAlert.Infra;
using StockAlert.Infra.Events;
using StockAlert.Infra.Types;
using StockAlert.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataTicker
{
    public class Module : IModule
    {
        private IServiceLocator serviceLocator_;

        public Module(IServiceLocator sl)
        {
            serviceLocator_ = sl;
        }

        public void Initialize()
        {
            // Create ticker view model
            var tickerViewModel = serviceLocator_.GetInstance<TickerViewModel>();
            tickerViewModel.StrollInterval = TimeSpan.FromMilliseconds(100);
            tickerViewModel.Start();
            
            // Add view to region
            var regionMgr = serviceLocator_.GetInstance<IRegionManager>();
            regionMgr.RegisterViewWithRegion(RegionNames.BodyRegion, () => new TickerView(tickerViewModel));
        }

    }
}
