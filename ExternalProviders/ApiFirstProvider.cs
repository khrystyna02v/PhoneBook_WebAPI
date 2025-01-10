using System.Text.Json;

namespace PhoneBook_webAPI.ExternalProviders
{
    public class ApiFirstProvider: IApiFirstProvider
    {
        private HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.first.org/data/v1/countries"),
        };

        public async Task<Dictionary<string, CountryInfo>> ReadCountries()
        {
            using var response = await httpClient.GetAsync("?limit=300&pretty=true");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var countryCodes = JsonSerializer.Deserialize<CountryInfoList>(jsonResponse).Data;
            return countryCodes;
        }
    }
}
