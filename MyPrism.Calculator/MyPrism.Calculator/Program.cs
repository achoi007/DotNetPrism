using Calculator;
using IOLibrary;
using Microsoft.Practices.Unity;
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
            // Print simple instruction.
            Console.WriteLine("Simple calculator service.\nEnter OP number number and hit return.\nUse blank line to terminate.");
            Console.WriteLine("Available OP: " + GetOps());

            // Create unity container and register types
            IUnityContainer uc = new UnityContainer();
            uc.RegisterType<ICalculator, SimpleCalculator>();
            uc.RegisterType<IInputService, ConsoleInputService>();
            uc.RegisterType<IOutputService, ConsoleOutputService>();
            uc.RegisterType<ICalculatorREPL, SimpleCalculatorRepl>();

            // Create calculator REPL and run
            ICalculatorREPL loop = uc.Resolve<ICalculatorREPL>();
            loop.Run();
        }

        static string GetOps()
        {
            var strArray = Enum.GetNames(typeof(CalculationType));
            return string.Join(", ", strArray);
        }
    }
}
