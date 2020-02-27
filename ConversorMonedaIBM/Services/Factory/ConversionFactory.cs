using System;
using System.Collections.Generic;
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
    public class ConversionFactory : IOperationFactory<Conversion>
    {
        public ConversionFactory()
        {
            
        }
        private readonly FromConversionSpecification _fromSpecification;
        private readonly RateConversionSpecification _rateSpecification;
        private readonly ToConversionSpecification _toSpecification;

        public ConversionFactory
        (FromConversionSpecification fromSpecification, 
            RateConversionSpecification rateSpecification, 
            ToConversionSpecification toSpecification)
        {
            _fromSpecification = fromSpecification;
            _rateSpecification = rateSpecification;
            _toSpecification = toSpecification;
        }

        public IOperation CreateInstance()
        {
            return new Conversion();
        }

        public IOperation CreateInstance(WebApiConversionData.Class1 conversions)
        {
            if (_rateSpecification.IsSatisfiedBy(conversions)&&
                _toSpecification.IsSatisfiedBy(conversions)&&
                _fromSpecification.IsSatisfiedBy(conversions))
            {
                return new Conversion()
                {
                    From = conversions.from,
                    ToConv = conversions.to,
                    NumRate = Convert.ToDouble(conversions.rate) 
                };
            }

            return null;
        }
    }


}