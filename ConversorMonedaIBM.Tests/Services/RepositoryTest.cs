using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.Comparer;
using ConversorMonedaIBM.Services.Repository;
using Effort.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Effort;
using Effort.DataLoaders;

namespace ConversorMonedaIBM.Tests.Services
{
    [TestClass()]
    public class RepositoryTest
    {
        private ConversorMonedaIBMContext _context;
        public GenericRepository<Transaction> _repository;
        private TransactionComprarer _transactionComprarer;
        private Transaction _transaction;
        private List<Transaction> _transactionList;

        private void CreateClientTest()
        {
            _transaction = new Transaction
            {
                Amount = 55,
                Currency = "EUR",
                ID = 6496461,
                Sku = "CAD"
            };
        }

        private void CreateTransactionList()
        {
            _transactionList = new List<Transaction>
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


        private async void PrepareData()
        {
            foreach (var item in _transactionList)
            {
                await _repository.Insert(item).ConfigureAwait(false);
            }


        }

        [TestMethod()]
        public void Repository_Test()
        {
            //var repository = new GenericRepository<Transaction>();

            Assert.IsNotNull(_repository);
            Assert.IsNotNull(_context);
            Assert.IsInstanceOfType(_context, typeof(DbContext));


        }

        [TestMethod()]
        public void GetAllTest()
        {
            var datas = _repository.GetAll();
            var actualList = datas.Result.ToList();
            var expectedList = _transactionList;

            int actualCount = actualList.ToList().Count;
            int expectedCount = expectedList.Count;

            Assert.IsNotNull(expectedList);
            Assert.IsInstanceOfType(expectedList, actualList.GetType());
            Assert.AreEqual(expectedCount, actualCount);

        }


        [TestMethod()]
        public void GetByIdTest()
        {
            Transaction expected = _transactionList.First();
            int? id = expected.ID;

            var actual = _repository.GetById(id).Result as Transaction;

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(expected, actual.GetType());
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.Currency, actual.Currency);
            Assert.AreEqual(expected.Sku, actual.Sku);
            Assert.AreEqual(expected.Amount, actual.Amount);
        }

        [TestMethod()]
        public void AddTest()
        {
            _repository.Insert(_transaction);

            var resultClient = _repository.GetAll().Result.First(c => _transactionComprarer.Compare(c, _transaction) == 0);

            Assert.IsNotNull(resultClient);
            Assert.AreEqual(_transaction.ID, resultClient.ID);
            Assert.AreEqual(_transaction.Amount, resultClient.Amount);
            Assert.AreEqual(_transaction.Currency, resultClient.Currency);
            Assert.AreEqual(_transaction.Sku, resultClient.Sku);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            Transaction transactionExisting = _repository.GetAll().Result.First();

            Assert.IsNotNull(transactionExisting);

            _repository.Delete(transactionExisting.ID);

            Transaction transactionDeleted = _repository.GetById(transactionExisting.ID).Result;

            Assert.IsNull(transactionDeleted);
        }


        [TestMethod()]
        public void UpdateTest()
        {
            var expectedName = "Nombre Modificado";
            Transaction transactionExisting = _repository.GetAll().Result.First();

            Assert.IsNotNull(transactionExisting);

            transactionExisting.Currency = transactionExisting.Currency;
            _repository.Update(transactionExisting);

            Transaction transactiontUpdated = _repository.GetById(transactionExisting.ID).Result;

            Assert.IsNotNull(transactiontUpdated);
            Assert.AreEqual(transactionExisting.ID, transactiontUpdated.ID);
            Assert.AreEqual(expectedName, transactiontUpdated.Currency);
        }
    }
}
