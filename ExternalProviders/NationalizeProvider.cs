using System.Text.Json;
namespace PhoneBook_webAPI.ExternalProviders
{
    public class NationalizeProvider: INationalizeProvider
    {
        private HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://api.nationalize.io"),
        };

        public async Task<List<CountryProbability>> GetCountryProbability(string name)
        {
            using var response = await httpClient.GetAsync($"?name={name}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var personProbability = JsonSerializer.Deserialize<PersonProbability>(jsonResponse);
            return personProbability.Country;
        }
    }
}
