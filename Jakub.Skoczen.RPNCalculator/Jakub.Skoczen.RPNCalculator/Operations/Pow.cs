using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class Pow : IOperation
    {
        public StackElement Operate(StackElement e1, StackElement e2)
        {
            double val1 = double.Parse(e1.Value);
            double val2 = double.Parse(e2.Value);
            return new StackElement(Math.Pow(val1, val2).ToString());
        }
    }
}
