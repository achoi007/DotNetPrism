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
        public ContainerCalculatorRepl(IUnityContainer c) :
            base(c.Resolve<ICalculator>(), 
                 c.Resolve<IInputService>(),
                 c.ResolveAll<IOutputService>())
        {
        }
    }
}
