using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class Div:IOperation
    {
        public StackElement operate(StackElement e1, StackElement e2)
        {
            return e1 / e2;
        }
    }
}
