using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorMonedaIBM.Services.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(params object[] keys);
        Task Insert(T obj);
        Task MeterOperaciones(List<T> lista);
        Task Update(T obj);
        Task Delete(params object[] id);
        Task Save();
    }
}
