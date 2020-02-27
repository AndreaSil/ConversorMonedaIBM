using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedaIBM.Services.Deserializer
{
    public interface IDeserializer<T> where T : class
    {
        Task<IEnumerable<T>> MakeGetRequestAsync();
    }
}
