using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using StockAlert.Infra.Events;
using StockAlert.Infra.Services;
using StockAlert.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockMarketData
{
    public class Module : IModule
    {
        private IServiceLocator serviceLocator_;
        private MockService mktDataService_;

        public Module(IServiceLocator serviceLocator)
        {
            serviceLocator_ = serviceLocator;
        }

        public void Initialize()
        {
            // Offer mock service
            mktDataService_ = serviceLocator_.GetInstance<MockService>();
            serviceLocator_.RegisterInstance<IMarketDataService, MockService>("", mktDataService_);
            mktDataService_.Start();
            mktDataService_.Subscribe("AAPL");
            mktDataService_.Subscribe("MSFT");
        }
    }
}
