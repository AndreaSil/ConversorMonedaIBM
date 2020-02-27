using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Services.Exceptions
{
    public class RateSpecificationException:Exception
    {
        public RateSpecificationException(string message) : base(message) { }

        public RateSpecificationException(string message, Exception inner) : base(message, inner) { }
    }
}