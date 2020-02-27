using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.ChekURL;
using ConversorMonedaIBM.Services.Deserializer;
using ConversorMonedaIBM.Services.Factory;
using ConversorMonedaIBM.Services.Repository;
using Newtonsoft.Json;

namespace ConversorMonedaIBM.Controllers
{
    public class TransactionsController : Controller
    {
        private ConversorMonedaIBMContext db = new ConversorMonedaIBMContext();
        private readonly IGenericRepository<Transaction> _repository;
        private readonly TransactionFactory _transactionFactory;
        private readonly TransactionDeserializer _transactionDeserializer;
        private readonly ICheckURL _checkUrl;

        public TransactionsController()
        {
            
        }

        public TransactionsController(IGenericRepository<Transaction> repository, TransactionFactory transactionFactory, TransactionDeserializer transactionDeserializer, ICheckURL checkUrl)
        {
            _repository = repository;
            _transactionFactory = transactionFactory;
            _transactionDeserializer = transactionDeserializer;
            _checkUrl = checkUrl;
        }
        // GET: Transactions
        public async Task<string> Index()
        {
            try
            {
              
                var listaTransactions = new List<Transaction>();
                if (await _checkUrl.Check())
                {
                    var listJson = _transactionDeserializer.MakeGetRequestAsync().Result.ToList();


                    foreach (var item in listJson)
                    {
                        var transaction = (Transaction)_transactionFactory.CreateInstance(item);
                        if (transaction != null)
                        {
                            listaTransactions.Add(transaction);
                            await _repository.Insert(transaction);
                        }
                    }
                    return Task.Run(() => JsonConvert.SerializeObject(listaTransactions)).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;


        }

      

       
    }
}
