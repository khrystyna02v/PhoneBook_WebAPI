using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PhoneBook_webAPI.ExternalProviders
{
    public class RestCountriesProvider: IRestCountriesProvider
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public RestCountriesProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("Apis:RestCountriesUrl");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public async Task<string> GetCapital(string code)
        {
            using var response = await _httpClient.GetAsync($"{code}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            jsonResponse = jsonResponse.Substring(1,jsonResponse.Length-2);

            var capital = JsonSerializer.Deserialize<CountryCapitalInfo>(jsonResponse).Capital[0];
            if (capital.Length == 0)
            {
                return null;
            }
            return capital;
        }
    }
}
