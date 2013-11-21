using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class Vat:IOperation
    {
        public StackElement Operate(StackElement e1, StackElement e2)
        {
            double val=double.Parse(e1.Value)*0.23;
            return new StackElement(val.ToString());
        }
    }
}
