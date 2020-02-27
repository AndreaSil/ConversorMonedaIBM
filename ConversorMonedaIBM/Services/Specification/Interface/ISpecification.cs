using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Models;

namespace ConversorMonedaIBM.Services.Specification.Interface
{
    public interface ISpecification<T> where T : class
    {
        bool IsSatisfiedBy(T obj);
    }
}
