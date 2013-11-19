using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator.CustomExceptions
{
    class InvalidDateTimeOperationException:Exception
    {
        const string message = "DateTime operation exception. Invalid DateTime format.";
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }
    }
}
