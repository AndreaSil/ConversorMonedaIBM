using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ConversorMonedaIBM.Services.Logs;
using Polly;

namespace ConversorMonedaIBM.Services.ChekURL
{
    public class CheckURL:ICheckURL
    {
        public CheckURL()
        {
            
        }
        public async Task<bool> Check()
        {
            var httpClient = new HttpClient();
            var request = await Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine("Escribir en Log");
                    //logger.Warning($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                })
                .ExecuteAsync(() => httpClient.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json"));
            return request.IsSuccessStatusCode;
        }
    }
}