using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using ConversorMonedaIBM.Controllers;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversorMonedaIBM.Tests.Controllers
{
    [TestClass]
    public class TransactionControllerTest
    {
        private ConversorMonedaIBMContext _entityContext;
        private List<Transaction> _transactions;
        private Transaction _transactionTest;
        private TransactionsController _transactionsController;
        private GenericRepository<Transaction> _fakeRepository;

        private void CreateTransactionTest()
        {
            _transactionTest = new Transaction
            {
                Amount = 1.01,
                Currency = "USD",
                ID = 123456789,
                Sku = "P8624"

            };
        }

        private void CreateTransactionList()
        {
            _transactions = new List<Transaction>
            {
                new Transaction
                {
                    Amount = 1.05,
                    Currency = "EUR",
                    ID = 123456744,
                    Sku = "P8614"
                },
                new Transaction
                {
                    Amount = 1.14,
                    Currency = "EUR",
                    ID = 123456644,
                    Sku = "S8614"
                },
                new Transaction
                {
                    Amount = 2.05,
                    Currency = "CAD",
                    ID = 123456744,
                    Sku = "P8611"
                }
            };
        }

        [TestMethod]
        public void IndexTestResult_OK()
        {
            var action = _transactionsController.Index();
            var result = action.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(string.IsNullOrEmpty(result));
            Assert.IsTrue(action.IsCompleted);
        }
    }
}
