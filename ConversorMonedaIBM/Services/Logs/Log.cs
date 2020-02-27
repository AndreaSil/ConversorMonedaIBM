using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Services.Logs
{
    public class Log: ILog
    {
        private readonly Transaction _transaction;

        public Log(Transaction transaction)
        {
            _transaction = transaction;
        }

        public Log() { }
        
        public void CrearLog(string ex)
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = @"\LogApi";
            File.AppendAllText(path + fileName, _transaction.Sku + " " + _transaction.ID + " " + _transaction.Amount +" "+ DateTime.Today.ToString("dddd, dd MMMM yyyy") + "new transaction");
        }
    }
}