using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SimpleCalculatorRepl : ICalculatorREPL
    {
        private List<IOutputService> outputServices;

        public SimpleCalculatorRepl(ICalculator calc, IInputService inputService, IEnumerable<IOutputService> outServices)
        {
            Calculator = calc;
            InputService = inputService;
            this.outputServices = new List<IOutputService>(outServices);
        }

        public ICalculator Calculator
        {
            get;
            set;
        }

        public IInputService InputService
        {
            get;
            set;
        }

        public IOutputService OutputService
        {
            get { return outputServices.FirstOrDefault(); }
            set
            {
                outputServices.Clear();
                outputServices.Add(value);
            }
        }

        public void Run()
        {
            while (InputService.GetNext())
            {
                var calcType = InputService.CalcType;
                var args = InputService.Args;
                var result = Calculator.Execute(calcType, args);
                string mesg = result.ToString();
                foreach (var outService in outputServices)
                {
                    outService.WriteMessage(mesg);
                }
            }
        }
    }
}
