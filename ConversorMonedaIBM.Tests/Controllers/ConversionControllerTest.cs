using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConversorMonedaIBM.Controllers;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversorMonedaIBM.Tests.Controllers
{
    public class ConversionControllerTest
    {
        private ConversorMonedaIBMContext _entityContext;
        private List<Conversion> _conversions;
        private Conversion _conversionTest;
        private ConversionsController __conversionsController;
        private GenericRepository<Conversion> _fakeRepository;


        private void CreateConversionTest()
        {
            _conversionTest = new Conversion
            {
                From = "EUR",
                ID = 547969,
                NumRate = 1.9,
                ToConv = "CAD"
            };
        }

        private void CreateConversionList()
        {
            _conversions = new List<Conversion>
            {
                new Conversion
                {
                    From = "EUR",
                    ID = 547969,
                    NumRate =0.9,
                    ToConv = "CAD"
                },
                new Conversion
                {
                    From = "EUR",
                    ID = 547969,
                    NumRate = 1.9,
                    ToConv = "CAD"
                },
                new Conversion
                {
                    From = "CAD",
                    ID = 547969,
                    NumRate = 1.3,
                    ToConv = "CAD"
                }
            };
        }

        [TestMethod]
        public void IndexTestResult_OK()
        {
            var action = __conversionsController.Index();
            var result = action.Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(string.IsNullOrEmpty(result));
            Assert.IsTrue(action.IsCompleted);
        }

    }
    }
