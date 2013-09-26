using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrism.Interfaces
{
    public interface ICalculatorREPL
    {
        ICalculator Calculator { get; set; }

        IInputService InputService { get; set; }

        IOutputService OutputService { get; set; }

        void Run();
    }
}
