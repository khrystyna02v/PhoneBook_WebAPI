﻿using System.Text.Json.Serialization;
using PhoneBook_webAPI.ExternalProviders;

namespace PhoneBook_webAPI
{
    public class CountryProbability
    {
        [JsonPropertyName("country_id")]
        public string CountryId { get; set; }

        [JsonPropertyName("probability")]
        public double Probability { get; set; }

        public CountryProbability(string countryId, double probability)
        {
            CountryId = countryId;
            Probability = probability;
        }
    }
}
