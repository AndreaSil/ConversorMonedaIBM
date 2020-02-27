using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Specification.Interface;

namespace ConversorMonedaIBM.Services.Specification.TransactionSpecification
{
    public class SkuTransactionSpecification:ISpecification<WebApiTransactionData.Class1>
    {
        public SkuTransactionSpecification()
        {
            
        }
        public bool IsSatisfiedBy(WebApiTransactionData.Class1 obj)
        {
            if (obj.sku != null && !String.IsNullOrEmpty(obj.sku))
            {
                return true;
            }

            return false;
        }
    }
}