using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class Sub:IOperation
    {
        public StackElement Operate(StackElement e1, StackElement e2)
        {
            return e1 - e2;
        }
    }
}
