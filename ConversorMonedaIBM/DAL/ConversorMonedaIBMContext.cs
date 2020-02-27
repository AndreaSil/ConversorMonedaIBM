using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.DAL
{
    public class ConversorMonedaIBMContext: DbContext
    {
        public ConversorMonedaIBMContext(): base("ConversorMonedaIBMContext")  { }
        
        public DbSet<Conversion> Conversions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}