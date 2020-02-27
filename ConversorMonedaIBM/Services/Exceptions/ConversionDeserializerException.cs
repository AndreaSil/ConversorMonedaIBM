using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Services.Exceptions
{
    public class ConversionDeserializerException:Exception
    {
        public ConversionDeserializerException(string message):base(message) { }

        public ConversionDeserializerException(string message, Exception inner):base(message,inner) { }
    }
}