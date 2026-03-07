using Domain.Entities.Models.ApiNinjasModels;
using DoYouKnowIt.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services.ApiNinjas
{
    public class ApiNinjasCountryService
    {
        private ApiNinjasClient _client;
        public ApiNinjasCountryService(ApiNinjasClient client) //Not interface
        {
            _client = client;
        }


        public async Task<Country> GetCountry(string iso2)
        {
            HttpResponseMessage response = await _client.Client.GetAsync($"v1/countryflag?country={iso2}");

            if (!response.IsSuccessStatusCode)
                return null !;

            Country country = null;
            string responseString = await response.Content.ReadAsStringAsync();
            country = JsonSerializer.Deserialize<Country>(responseString);

            return country;
        }
    }
}
