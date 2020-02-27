using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.Interface;

namespace ConversorMonedaIBM.Services.Factory
{
    public interface IOperationFactory<T> where T:class
    {
        IOperation CreateInstance();
    }
}
