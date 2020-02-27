using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models.Interface;

namespace ConversorMonedaIBM.Models.Data
{
    public class Transaction:IOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Sku { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}