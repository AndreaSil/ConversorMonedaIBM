using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Tests.DAL
{
    public class ConversorMonedaIBMContextTest: DbContext
    {
        public ConversorMonedaIBMContextTest()
        {
            
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Conversion> Conversions { get; set; }


        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Transaction>().HasKey(c=>new {c.Sku,c.Amount,c.Currency,ID=c.ID});
        }
    }
}
