using System.Text.Json.Serialization;
namespace PhoneBook_webAPI.CountryPredictionClasses
{
    public class CountryCapitalInfo
    {
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }

    }
}