using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedaIBM.Services.ChekURL
{
    public interface ICheckURL
    {
        Task<bool> Check();
    }
}
