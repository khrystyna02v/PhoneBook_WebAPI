using System.Text.Json.Serialization;

namespace PhoneBook_webAPI
{
    public class PersonProbability
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("country")]
        public List<CountryProbability> Country { get; set; }
        public PersonProbability() 
        {
            Name = null;
            Country = new List<CountryProbability>();
            Count = 0;
        }
        public PersonProbability(int count, string name, List<CountryProbability> country)
        {
            Name = name;
            Country = country;
            Count = count;
        }
        public List<CountryProbability> getCountry()
        {
            return Country;
        }
    }
}
