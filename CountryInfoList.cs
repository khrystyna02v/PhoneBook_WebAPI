using System.Text.Json.Serialization;
namespace PhoneBook_webAPI
{
    public class CountryInfoList
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("status-code")]
        public int StatusCode { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("access")]
        public string Access { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        [JsonPropertyName("data")]
        public Dictionary<string, CountryInfo> Data { get; set; }
    }
}
