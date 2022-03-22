using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling
{
    internal class NoOperatorException : Exception
    {
        public NoOperatorException() : base() { }
        public NoOperatorException(string message) : base(message) { }
    }
}
