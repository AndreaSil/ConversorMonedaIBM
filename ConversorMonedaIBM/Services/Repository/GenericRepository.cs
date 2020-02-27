using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using ConversorMonedaIBM.DAL;

namespace ConversorMonedaIBM.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private ConversorMonedaIBMContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context= new ConversorMonedaIBMContext();
            table = _context.Set<T>();
        }

        //public GenericRepository(ConversorMonedaIBMContext _context)
        //{
        //    this._context = _context;
        //    table = _context.Set<T>();
        //}

        public async Task Delete(params object[] id)
        {
            var obj = await table.FindAsync(id).ConfigureAwait(false);
            if (obj != null)
                await Task.Run(() => table.Remove(obj));
            await Save().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetById(params object[] keys)
        {
            if (keys.All(id => id == null))
            {
                return null;
            }
            return await table.FindAsync(keys);
        }

        public async Task Insert(T obj)
        {
            table.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task MeterOperaciones(List<T> lista)
        {
            foreach (var item in lista)
            {
                await Task.Run(() => table.Add(item)).ConfigureAwait(false);
            }
        }

        public async Task Save()
        {

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await Save().ConfigureAwait(false);
        }
    }
}