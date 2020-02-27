using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Models.WebAPI
{
    public class WebApiTransactionData
    {
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string sku { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }
        }

    }
}