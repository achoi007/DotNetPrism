using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOLibrary
{
    public class ConsoleInputService : IInputService
    {
        public ConsoleInputService()
        {
            Args = new Arguments();
        }

        public bool GetNext()
        {
            // Read line
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return false;
            }

            // Split into fields
            char[] separator = { ' ' };
            var fields = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Length < 3)
            {
                throw new FormatException("Expecting at least 3 fields from line: " + line);
            }

            // Extract calculator type
            CalcType = (CalculationType)Enum.Parse(typeof(CalculationType), fields[0]);

            // Extract arguments
            Args.X = int.Parse(fields[1]);
            Args.Y = int.Parse(fields[2]);

            return true;
        }

        public Arguments Args
        {
            get;
            private set;
        }

        public CalculationType CalcType
        {
            get;
            private set;
        }
    }
}
