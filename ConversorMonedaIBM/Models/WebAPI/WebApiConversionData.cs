using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConversorMonedaIBM.Models.WebAPI
{
    public class WebApiConversionData
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string from { get; set; }
            public string to { get; set; }
            public string rate { get; set; }
        }

    }
}