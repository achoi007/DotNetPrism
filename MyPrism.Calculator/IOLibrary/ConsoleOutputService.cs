using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLibrary
{
    public class ConsoleOutputService : IOutputService
    {
        public void WriteMessage(string mesg)
        {
            Console.WriteLine(mesg);
        }
    }
}
