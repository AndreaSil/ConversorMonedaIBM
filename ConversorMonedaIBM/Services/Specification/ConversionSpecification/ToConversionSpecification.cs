using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Specification.Interface;

namespace ConversorMonedaIBM.Services.Specification.ConversionSpecification
{
    public class ToConversionSpecification:ISpecification<WebApiConversionData.Class1>
    {
        public ToConversionSpecification()
        {
            
        }
        public bool IsSatisfiedBy(WebApiConversionData.Class1 obj)
        {
            if (obj.to != null && !String.IsNullOrEmpty(obj.to))
            {
                return true;
            }

            return false;
        }
    }
}