using System.Text.Json.Serialization;

namespace PhoneBook_webAPI
{
    public class CountryProbabilityViewModel
    {
        [JsonPropertyName("country_id")]
        public string CountryId { get; set; }

        [JsonPropertyName("probability")]
        public double Probability { get; set; }

        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        public CountryProbabilityViewModel(CountryProbability countryProbability, string? countryName = null)
        {
            CountryId = countryProbability.CountryId;
            Probability = countryProbability.Probability;
            CountryName = countryName;
        }
    }
}
