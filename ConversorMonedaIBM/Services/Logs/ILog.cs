using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Services.Logs
{
    public interface ILog
    {
        void CrearLog(string ex);
    }
}
