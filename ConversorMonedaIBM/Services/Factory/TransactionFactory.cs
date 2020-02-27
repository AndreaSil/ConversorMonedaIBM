using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Models.Interface;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Specification.ConversionSpecification;
using ConversorMonedaIBM.Services.Specification.TransactionSpecification;

namespace ConversorMonedaIBM.Services.Factory
{
    public class TransactionFactory:IOperationFactory<Transaction>
    {
       

        private readonly AmountTransactionSpecification _amountSpecification;
        private readonly CurrencyTransactionSpecification _currencySpecification;
        private readonly SkuTransactionSpecification _skuSpecification;

        
        public TransactionFactory
            (AmountTransactionSpecification amountSpecification, 
            CurrencyTransactionSpecification currencySpecification,
            SkuTransactionSpecification skuSpecification)
        {
           
            _amountSpecification=amountSpecification;
            _currencySpecification=currencySpecification;
            _skuSpecification= skuSpecification;
        }

        public IOperation CreateInstance()
        {
            return new Transaction();
        }

        public IOperation CreateInstance(WebApiTransactionData.Class1 transaction)
        {
            if (_currencySpecification.IsSatisfiedBy(transaction)&&
                _amountSpecification.IsSatisfiedBy(transaction)&&
                _skuSpecification.IsSatisfiedBy(transaction))
            {
                return new Transaction()
                {
                    Amount = Convert.ToDouble(transaction.amount),
                    Currency = transaction.currency,
                    Sku = transaction.sku

                };
            }

            return null;
        }
    }
}