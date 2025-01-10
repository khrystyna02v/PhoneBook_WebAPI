using System.Text.Json.Serialization;
namespace PhoneBook_webAPI
{
    public class CountryInfoList
    {
        [JsonPropertyName("data")]
        public Dictionary<string, CountryInfo> Data { get; set; }
    }
}
