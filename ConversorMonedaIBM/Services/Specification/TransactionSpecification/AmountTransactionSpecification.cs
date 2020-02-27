using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Specification;
using ConversorMonedaIBM.Services.Specification.Interface;

namespace ConversorMonedaIBM.Services.Specification.TransactionSpecification
{
    public class AmountTransactionSpecification: ISpecification<WebApiTransactionData.Class1>
    {
        public AmountTransactionSpecification()
        {
            
        }
        public bool IsSatisfiedBy(WebApiTransactionData.Class1 obj)
        {
            if (obj.amount !=null && !String.IsNullOrEmpty(obj.amount))
            {
                return true;
            }

            return false;
        }
    }
}