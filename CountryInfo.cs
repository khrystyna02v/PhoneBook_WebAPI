using System.Text.Json.Serialization;

namespace PhoneBook_webAPI
{
    public class CountryInfo
    {
        [JsonPropertyName("country")]
        public string CountryName { get; set; }
        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
