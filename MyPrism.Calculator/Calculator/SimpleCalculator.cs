using MyPrism.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SimpleCalculator : ICalculator
    {
        public int Execute(CalculationType calcType, Arguments args)
        {
            switch (calcType)
            {
                case CalculationType.Add:
                    return args.X + args.Y;

                case CalculationType.Sub:
                    return args.X - args.Y;

                case CalculationType.Mul:
                    return args.X * args.Y;

                case CalculationType.Div:
                    return args.X / args.Y;

                default:
                    throw new ArgumentException("Unknown calc type: " + calcType);
            }
        }
    }
}
