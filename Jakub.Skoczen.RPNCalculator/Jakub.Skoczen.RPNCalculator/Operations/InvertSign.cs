using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.Operations
{
    class InvertSign:IOperation
    {
        public StackElement operate(StackElement e1, StackElement e2=null)
        {
            double val = Double.Parse(e1.Value);
            if (Math.Sign(val) > 0)
                val = -val;
            else
                val = val * -1;

            e1.Value = val.ToString();
            return e1;
        }
    }
}
