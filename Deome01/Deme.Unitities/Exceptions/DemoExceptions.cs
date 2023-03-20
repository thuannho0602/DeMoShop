using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deme.Unitities.Exceptions
{
    public class DemoExceptions : Exception
    {
        public DemoExceptions()
        {
        }

        public DemoExceptions(string message)
            : base(message)
        {
        }

        public DemoExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    
    }
}
