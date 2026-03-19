namespace DoYouKnowIt.Infrastructure.Connections
{
    public class ApiNinjasDataManager
    {
        
        private readonly string baseUrl = "https://api.api-ninjas.com/";
        private readonly string mykeyHeader = "X-Api-Key";
        private readonly string myKey = "v7ZaTeWShVN2gMG80yebFQBBrcw3xoVe9jOodTkm"; // :D

        public HttpClient Client { get;}
        public ApiNinjasDataManager()
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
