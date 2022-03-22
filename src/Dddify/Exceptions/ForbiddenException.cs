using System;
using System.Collections.Generic;
using System.Linq;

namespace Dddify.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
           : base("The specified resource was forbidden.")
        {
        }

        public ForbiddenException(string message)
            : base(message)
        {
        }
    }
}
