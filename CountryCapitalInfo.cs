using System.Text.Json.Serialization;
namespace PhoneBook_webAPI
{
    public class CountryCapitalInfo
    {
        [JsonPropertyName("capital")]
        public string[] Capital { get; set; }

    }
}