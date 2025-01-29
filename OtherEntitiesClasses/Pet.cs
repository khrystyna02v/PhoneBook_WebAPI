using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Other_entities_classes
{
    [Table(name: "Pets", Schema = "PhoneBook")]
    public class Pet
    {
        public int? PetId { get; set; }
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }

        [ForeignKey("AnimalTypeId")]
        [JsonIgnore]
        public virtual Animal Animal { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Person Owner { get; set;  }

        public Pet() { }
        public Pet(string name, int animal, DateTime? date, int ownerId)
        {
            Name = name;
            AnimalTypeId = animal;
            DateOfBirth = date;
            OwnerId = ownerId;
        }
    }
}