using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Services.Repository
{
    public class FakeRepository:IGenericRepository<Transaction>
    {
        public ConversorMonedaIBMContext _context = null;
        public List<Transaction> _fakeTransaction= new List<Transaction>();
        public DbSet<Transaction> table = null;
        public async Task<IEnumerable<Transaction>> GetAll()
        {
       
            return await table.ToListAsync().ConfigureAwait(false);
        }

        public Task<Transaction> GetById(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Transaction obj)
        {
            throw new NotImplementedException();
        }

        public async Task MeterOperaciones(List<Transaction> lista)
        {
            var listTransaction = new List<Transaction>
            {
                new Transaction
                {
                    Amount = 154,
                    Currency = "EUR",
                    ID = 46464,
                    Sku = "CAD"
                },
                new Transaction
                {
                    Amount = 54,
                    Currency = "EUR",
                    ID = 44464,
                    Sku = "CAD"

                }
            };

        }

        public Task Update(Transaction obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(params object[] id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}