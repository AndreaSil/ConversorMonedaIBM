using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models.Interface;

namespace ConversorMonedaIBM.Models.Data
{
    public class Conversion:IOperation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string From { get; set; }
        public string ToConv { get; set; }
        public double NumRate { get; set; }
    }
}