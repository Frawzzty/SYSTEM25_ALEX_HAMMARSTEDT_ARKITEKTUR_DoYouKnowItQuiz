using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Infrastructure.Data
{
    public class ApiNinjasClient
    {
        //https://api.api-ninjas.com/v1/countryflag?country=US
        private readonly string baseUrl = "https://api.api-ninjas.com/";
        private readonly string mykeyHeader = "X-Api-Key";
        private readonly string myKey = "v7ZaTeWShVN2gMG80yebFQBBrcw3xoVe9jOodTkm"; // :D

        public HttpClient Client { get;}
        public ApiNinjasClient()
        {
            Client = SetClient();
        }
        private HttpClient SetClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add(mykeyHeader, myKey);

            return client;
        }

    }
}
