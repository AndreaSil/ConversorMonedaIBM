using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Exceptions;
using Newtonsoft.Json;
using ConversorMonedaIBM.Services.Logs;

namespace ConversorMonedaIBM.Services.Deserializer
{
    public class ConversionDeserializer : IDeserializer<WebApiConversionData.Class1>
    {
        private readonly ILog _log;
        public ConversionDeserializer(ILog log)
        {
            _log = log;
        }

        public ConversionDeserializer()
        {
            
        }
        public async System.Threading.Tasks.Task<IEnumerable<WebApiConversionData.Class1>> MakeGetRequestAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json").Result;
                    var content = response.Content.ReadAsStringAsync().Result;
                    var list = JsonConvert.DeserializeObject<List<WebApiConversionData.Class1>>(content);
                    if (list.ToString().Equals(" "))
                    {
                        throw new ConversionDeserializerException("Lista vacía");
                    }
                    return list;
                }
                catch (ConversionDeserializerException ex)
                {
                    _log.CrearLog(ex.Message);
                    throw new ServiceException("Error al deserializr JSON URL Conversión", ex);

                }
            }
        }
    }
}