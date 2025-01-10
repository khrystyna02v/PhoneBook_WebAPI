using System.Text.Json;

namespace PhoneBook_webAPI.ExternalProviders
{
    public class NationalizeProvider: INationalizeProvider
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public NationalizeProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("Apis:NationalizeUrl");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public async Task<List<CountryProbability>> GetCountryProbability(string name)
        {
            using var response = await _httpClient.GetAsync($"?name={name}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var personProbability = JsonSerializer.Deserialize<PersonProbability>(jsonResponse);
            return personProbability.Country;
        }
    }
}
