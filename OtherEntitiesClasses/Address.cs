using PhoneBook_webAPI.PersonClasses;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhoneBook_webAPI.Other_entities_classes
{
    [Table(name: "Address", Schema = "PhoneBook")]
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Building { get; set; }
        public int? Apartment { get; set; }
        [JsonIgnore]
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        [JsonIgnore]
        public virtual Person Owner { get; set; }

        public Address() { }
        public Address(string country, string city, string street, int building, int? apartment, int ownerId)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
            OwnerId = ownerId;
        }
    }
}