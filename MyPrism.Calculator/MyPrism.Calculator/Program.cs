using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            // Create unity container and use configuration file to configure it.
            IUnityContainer uc = new UnityContainer();
            var ucConfig = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            ucConfig.Configure(uc);

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
