using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Services.Exceptions
{
    public class TransactionDeserializerException: Exception
    {
        public TransactionDeserializerException(string message) : base(message) { }

        public TransactionDeserializerException(string message, Exception inner) : base(message, inner) { }
    }
}