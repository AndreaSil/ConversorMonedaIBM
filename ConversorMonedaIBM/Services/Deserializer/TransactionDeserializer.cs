using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ConversorMonedaIBM.Models;
using ConversorMonedaIBM.Models.WebAPI;
using ConversorMonedaIBM.Services.Exceptions;
using ConversorMonedaIBM.Services.Logs;
using Newtonsoft.Json;

namespace ConversorMonedaIBM.Services.Deserializer
{
    public class TransactionDeserializer:IDeserializer<WebApiTransactionData.Class1>
    {
        private readonly ILog _log;
        public TransactionDeserializer(ILog log)
        {
            _log = log;
        }

        public TransactionDeserializer()
        {
            
        }
        public async Task<IEnumerable<WebApiTransactionData.Class1>> MakeGetRequestAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json").Result;
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    var lista = JsonConvert.DeserializeObject<List<WebApiTransactionData.Class1>>(contenido);
                    if (lista.ToString().Equals(" "))
                    {
                        throw new TransactionDeserializerException("Lista vacía");
                    }
                    return lista;
                }
                catch (TransactionDeserializerException ex)
                {
                    _log.CrearLog(ex.Message);
                    throw new ServiceException("Error al deserializr JSON URL transaccion", ex);
                }
            }
        }
    }
}