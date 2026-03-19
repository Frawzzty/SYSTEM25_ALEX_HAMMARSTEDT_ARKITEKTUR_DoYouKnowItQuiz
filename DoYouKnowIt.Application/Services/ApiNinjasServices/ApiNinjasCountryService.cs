using Domain.Entities.Models.ApiNinjasModels;
using DoYouKnowIt.Infrastructure.Connections;
using System.Diagnostics;
using System.Text.Json;

namespace DoYouKnowIt.Application.Services.ApiNinjasServices
{
    public class ApiNinjasCountryService
    {
        private ApiNinjasDataManager _apiNinjas;
        public ApiNinjasCountryService(ApiNinjasDataManager apiNinjas) //Not interface
        {
            _apiNinjas = apiNinjas;
        }


        public async Task<Country> GetCountryFlags(string iso2)
        {
            HttpResponseMessage response = await _apiNinjas.Client.GetAsync($"v1/countryflag?country={iso2}");

            if (!response.IsSuccessStatusCode)
                return null !;

            Country country = null;
            string responseString = await response.Content.ReadAsStringAsync();
            
            try
            {
                country = JsonSerializer.Deserialize<Country>(responseString);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine($"{nameof(GetCountryFlags)} failed. Could not Deserialize response string");
            }
            
            return country;
        }
    }
}
