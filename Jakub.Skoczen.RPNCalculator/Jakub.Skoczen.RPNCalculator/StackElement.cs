using Jakub.Skoczen.RPNCalculator.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator
{
    public class StackElement
    {
        private string _value;

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    _value = value;
            }
        }

        public StackElement(string value)
        {
            Value = value;
        }

        public static StackElement operator +(StackElement e1, StackElement e2)
        {
            return new StackElement ((double.Parse(e1.Value)+double.Parse(e2.Value)).ToString());
        }

        public static StackElement operator -(StackElement e1, StackElement e2)
        {
            return new StackElement((double.Parse(e1.Value) - double.Parse(e2.Value)).ToString());
        }

        public static StackElement operator *(StackElement e1, StackElement e2)
        {
            return new StackElement((double.Parse(e1.Value) * double.Parse(e2.Value)).ToString());
        }

        public static StackElement operator /(StackElement e1, StackElement e2)
        {
            double e2Val=double.Parse(e2.Value);
            if ( e2Val== 0)
                throw new DivideByZeroException();
            return new StackElement((double.Parse(e1.Value) / e2Val).ToString());
        }

        public static StackElement operator +(StackElement e1, DateTime dt)
        {
            DateTime d;
            DateTime.TryParse(e1.Value,out d);
            if (d == new DateTime())
                throw new InvalidDateTimeOperationException();
           
            long ticks= d.Ticks+dt.Ticks;
            TimeSpan ts = new TimeSpan(ticks);      
            return new StackElement(ts.Ticks.ToString());
        }
     
        public static StackElement operator -(StackElement e1, DateTime dt)
        {
            DateTime d;
            DateTime.TryParse(e1.Value, out d);
            if (d == new DateTime())
                throw new InvalidDateTimeOperationException();
            long ticks = d.Ticks - dt.Ticks;
            TimeSpan ts = new TimeSpan(ticks);            
            return new StackElement(ts.Ticks.ToString());
        }

        public void InvertValueSign()
        {
            double val=Double.Parse(Value);
            if (Math.Sign(val) > 0)
                val = -val;
            else
                val =  val * -1;

            Value = val.ToString();
        }
    }
}
