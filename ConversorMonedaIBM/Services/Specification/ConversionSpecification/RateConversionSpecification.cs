using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Exceptions;
using ConversorMonedaIBM.Services.Logs;
using ConversorMonedaIBM.Services.Specification.Interface;
using Microsoft.Ajax.Utilities;

namespace ConversorMonedaIBM.Services.Specification.ConversionSpecification
{
    public class RateConversionSpecification:ISpecification<WebApiConversionData.Class1>
    {
        private readonly ILog _log;
        public RateConversionSpecification(ILog log)
        {
            _log = log;
        }
        public bool IsSatisfiedBy(WebApiConversionData.Class1 obj)
        {
            try
            {
                if (obj.rate != null && !String.IsNullOrEmpty(obj.rate))
                {
                    return true;
                }

                throw new RateSpecificationException("Error en RateConversionSpecification");
            }
            catch (RateSpecificationException ex)
            {
                _log.CrearLog(ex.Message);
                throw new ServiceException("Error al pasar las validaciones");
            }
           
        }
    }
}