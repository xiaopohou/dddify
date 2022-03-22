using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.MyProject.Domain.Exceptions
{
    public class UnsupportedColourException : Exception
    {
        public UnsupportedColourException(string code) 
            : base($"Colour \"{code}\" is unsupported.")
        {
        }
    }
}
