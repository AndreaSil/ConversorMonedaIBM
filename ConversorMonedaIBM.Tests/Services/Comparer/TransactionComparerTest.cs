using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.Comparer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversorMonedaIBM.Tests.Services.Comparer
{
    [TestClass()]
    public class TransactionComparerTest
    {
        private Transaction _transaction;
        private Transaction _transactionCopy;
        private IComparer<Transaction> _comparer;
        private int _sameTransaction = 0;

        [TestInitialize]
        public void TestInitialixe()
        {
            _transaction = new Transaction
            {
                Amount = 1.4,
                Currency = "CAD",
                ID = 54156,
                Sku = "MD546"
            };

            _transactionCopy= new Transaction
            {
                Amount = 1.4,
                Currency = "CAD",
                ID = 54156,
                Sku = "MD546"
            };
            _comparer= new TransactionComprarer();
        }

        [TestMethod()]
        public void CompareTest_Result_Same_Transaction()
        {
            var actual = _comparer.Compare(_transaction, _transactionCopy);

            Assert.AreEqual(actual,_sameTransaction);
        }
        [TestMethod]
        public void CompareTest_Result_Different_Transaction_Different_SKU()
        {
            var transactionDifferentSKU = _transactionCopy;
            transactionDifferentSKU.Sku = "T2222";

            var actual = _comparer.Compare(_transaction, transactionDifferentSKU);

            Assert.AreNotEqual(actual,_sameTransaction);
        }
        [TestMethod]
        public void CompareTest_Result_Different_Transaction_Different_Amount()
        {
            var transactionDifferentAmount = _transactionCopy;
            transactionDifferentAmount.Amount = 159;

            var actual = _comparer.Compare(_transaction, transactionDifferentAmount);

            Assert.AreNotEqual(actual, _sameTransaction);
        }

        [TestMethod]
        public void CompareTest_Result_Different_Transaction_Different_Currency()
        {
            var transactionDifferentCurrency = _transactionCopy;
            transactionDifferentCurrency.Currency = "USD";

            var actual = _comparer.Compare(_transaction, transactionDifferentCurrency);

            Assert.AreNotEqual(actual, _sameTransaction);
        }





    }
}
