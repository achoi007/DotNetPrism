using Calculator;
using IOLibrary;
using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrism.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple calculator service.\nEnter OP number number and hit return.\nUse blank line to terminate.");
            Console.WriteLine("Available OP: " + GetOps());

            ICalculator calc = new SimpleCalculator();
            IInputService inputService = new ConsoleInputService();
            IOutputService outputService = new ConsoleOutputService();
            ICalculatorREPL loop = new SimpleCalculatorRepl(calc, inputService, outputService);
            loop.Run();
        }

        static string GetOps()
        {
            var strArray = Enum.GetNames(typeof(CalculationType));
            return string.Join(", ", strArray);
        }
    }
}
