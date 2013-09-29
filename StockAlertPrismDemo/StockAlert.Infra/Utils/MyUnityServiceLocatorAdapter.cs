using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAlert.Infra.Utils
{
    public class MyUnityServiceLocatorAdapter : UnityServiceLocatorAdapter
    {
        public MyUnityServiceLocatorAdapter(IUnityContainer uc) : base(uc)
        {
            Container = uc;
        }

        public IUnityContainer Container { get; set; }
    }
}
