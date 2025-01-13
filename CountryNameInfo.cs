﻿using System.Text.Json.Serialization;

namespace PhoneBook_webAPI
{
    public class CountryNameInfo
    {
        [JsonPropertyName("name")]
        public Dictionary<string, object> Country { get; set; }
        public string CountryName => Country["common"].ToString();
    }
}
