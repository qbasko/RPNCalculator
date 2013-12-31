using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class InvertSign:IOperation
    {
        public StackElement Operate(StackElement e1, StackElement e2)
        {
            double val = Double.Parse(e1.Value);      
            return new StackElement((val * -1).ToString());
           
        }
    }
}
