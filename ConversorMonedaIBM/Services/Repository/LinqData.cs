using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Models.WebAPI;
using Newtonsoft.Json;

namespace ConversorMonedaIBM.Services.Repository
{
    public class LinqData
    {
         ConversorMonedaIBMContext _context;
         GenericRepository<Conversion> _conversionRepository;
         private GenericRepository<Transaction> _transactionRepository;
         public async Task<string> GetAllConversions()
         {
             var query = await _conversionRepository.GetAll();
             string result = JsonConvert.SerializeObject(query);
             return result;
         }
         public async Task<string> GetAllTransactions()
         {
             var query = await _transactionRepository.GetAll();
             string result = JsonConvert.SerializeObject(query);
             return result;
         }
         //public async Task<List<WebApiTransactionData>> GettransacionBySKU(string sku)
         //{
         //    //var listado = (from transacion in _context.Transactions
         //    //    where transacion.Currency == sku
         //    //    select transacion).ToList();
         //    //return listado;
         //}

    }
}