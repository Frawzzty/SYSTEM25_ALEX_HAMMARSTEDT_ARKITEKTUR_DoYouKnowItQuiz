namespace DoYouKnowIt.Infrastructure.Connections
{
    public class ApiNinjasConnection
    {
        
        private readonly string baseUrl = "https://api.api-ninjas.com/";
        private readonly string mykeyHeader = "X-Api-Key";
        private readonly string myKey = "v7ZaTeWShVN2gMG80yebFQBBrcw3xoVe9jOodTkm"; //Super secret

        public HttpClient Client { get;}
        public ApiNinjasConnection()
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
