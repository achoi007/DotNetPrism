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
        public SimpleCalculatorRepl(ICalculator calc, IInputService inputService, IOutputService outputService)
        {
            Calculator = calc;
            InputService = inputService;
            OutputService = outputService;
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
            get;
            set;
        }

        public void Run()
        {
            while (InputService.GetNext())
            {
                var calcType = InputService.CalcType;
                var args = InputService.Args;
                var result = Calculator.Execute(calcType, args);
                OutputService.WriteMessage(result.ToString());
            }
        }
    }
}
