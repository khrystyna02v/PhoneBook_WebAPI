using System.Text.Json;

namespace PhoneBook_webAPI.ExternalProviders
{
    public class ApiFirstProvider: IApiFirstProvider
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ApiFirstProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("Apis:ApiFirstUrl");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public async Task<Dictionary<string, CountryInfo>> ReadCountries()
        {
            using var response = await _httpClient.GetAsync("?limit=300&pretty=true");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var countryCodes = JsonSerializer.Deserialize<CountryInfoList>(jsonResponse).Data;
            return countryCodes;
        }
    }
}
