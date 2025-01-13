using System.Text.Json.Serialization;

namespace PhoneBook_webAPI
{
    public class CountryProbabilityViewModel
    {

        [JsonPropertyName("probability")]
        public double Probability { get; set; }

        [JsonPropertyName("country_id")]
        public string CountryId { get; set; }

        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        [JsonPropertyName("capital")]
        public string? Capital { get; set; }

        public CountryProbabilityViewModel(CountryProbability countryProbability, string? countryName, string? capital)
        {
            CountryId = countryProbability.CountryId;
            Probability = countryProbability.Probability;
            CountryName = countryName;
            Capital = capital;
        }
    }
}
