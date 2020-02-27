using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Exceptions;
using ConversorMonedaIBM.Services.Logs;
using ConversorMonedaIBM.Services.Specification.Interface;

namespace ConversorMonedaIBM.Services.Specification.ConversionSpecification
{
    public class FromConversionSpecification:ISpecification<WebApiConversionData.Class1>
    {
        private readonly ILog _log;

        public FromConversionSpecification(ILog log)
        {
            _log = log;
        }

        public bool IsSatisfiedBy(WebApiConversionData.Class1 obj)
        {
            try
            {
                if (obj.from != null && !String.IsNullOrEmpty(obj.from))
                {
                    return true;
                }

                throw new FromSpecificationException("Error en FromConversionSpecification");
                
            }
            catch (FromSpecificationException ex)
            {
                _log.CrearLog(ex.Message);
                throw new ServiceException("Error al pasar las validaciones");
            }
            
        }
    }
}