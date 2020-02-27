using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ConversorMonedaIBM.DAL;
using ConversorMonedaIBM.Models.Data;
using ConversorMonedaIBM.Services.ChekURL;
using ConversorMonedaIBM.Services.Deserializer;
using ConversorMonedaIBM.Services.Factory;
using ConversorMonedaIBM.Services.Repository;
using Newtonsoft.Json;

namespace ConversorMonedaIBM.Controllers
{
    public class ConversionsController : Controller
    {
        private ConversorMonedaIBMContext db = new ConversorMonedaIBMContext();
        private readonly IGenericRepository<Conversion> _repository;
        private readonly ConversionFactory _conversionFactory;
        private readonly ConversionDeserializer _conversionDeserializer;
        private readonly ICheckURL _checkConversionUrl;

        public ConversionsController()
        {
        }

        public ConversionsController
        (IGenericRepository<Conversion> repository,
            ConversionFactory conversionFactory,
            ConversionDeserializer conversionDeserializer,
            ICheckURL checkConversionUrl)
        {
            _repository = repository;
            _conversionFactory = conversionFactory;
            _conversionDeserializer = conversionDeserializer;
            _checkConversionUrl = checkConversionUrl;


        }

        // GET: Conversions
        public async Task<string> Index()
        {
            var listaConversiones = new List<Conversion>();
            if (await _checkConversionUrl.Check())
            {
                var listJson = _conversionDeserializer.MakeGetRequestAsync().Result;
                //_repository.MeterOperaciones(listaJson)

                foreach (var item in listJson)
                {
                    var conversion = (Conversion) _conversionFactory.CreateInstance(item);
                    if (conversion != null)
                    {
                        listaConversiones.Add(conversion);
                        await _repository.Insert(conversion);
                    }
                }

            }

            _repository.Save();
            return Task.Run(() => JsonConvert.SerializeObject(listaConversiones)).Result;
        }
    }
}

      

