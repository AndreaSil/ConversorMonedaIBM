using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Specification.Interface;

namespace ConversorMonedaIBM.Services.Specification.TransactionSpecification
{
    public class CurrencyTransactionSpecification:ISpecification<WebApiTransactionData.Class1>
    {
        public CurrencyTransactionSpecification()
        {
            
        }
        public bool IsSatisfiedBy(WebApiTransactionData.Class1 obj)
        {
            if (obj.currency != null && !String.IsNullOrEmpty(obj.currency))
            {
                return true;
            }

            return false;
        }
    }
}