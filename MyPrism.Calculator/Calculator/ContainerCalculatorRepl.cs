using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ContainerCalculatorRepl : SimpleCalculatorRepl
    {
        public ContainerCalculatorRepl(IServiceLocator srvLocate) :
            base(srvLocate.GetInstance<ICalculator>(),
                 srvLocate.GetInstance<IInputService>(),
                 srvLocate.GetAllInstances<IOutputService>())
        {
        }
    }
}
