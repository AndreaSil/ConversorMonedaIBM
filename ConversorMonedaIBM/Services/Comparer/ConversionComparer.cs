using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConversorMonedaIBM.Models.Data;

namespace ConversorMonedaIBM.Services.Comparer
{
    public class ConversionComparer : IComparer<Conversion>
    {
        public int Compare(Conversion x, Conversion y)
        {
            bool theSame = (x.ID == y.ID)
                           && (x.ToConv == y.ToConv)
                           && (x.From == y.From)
                           && (x.NumRate == y.NumRate);
            return theSame ? 0 : 1;
        }
    }
}