using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Services.Exceptions
{
    public class FromSpecificationException:Exception
    {
        public FromSpecificationException(string message) : base(message) { }

        public FromSpecificationException(string message, Exception inner) : base(message, inner) { }
    }
}