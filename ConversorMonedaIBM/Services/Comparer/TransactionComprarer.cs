using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Services.Comparer
{
    public class TransactionComprarer: IComparer<Transaction>
    {
        public int Compare(Transaction x, Transaction y)
        {
            bool theSame = (x.ID == y.ID)
                           && (x.Currency == y.Currency)
                           && (x.Amount == y.Amount);
            return theSame ? 0 : 1;
        }
    }
}