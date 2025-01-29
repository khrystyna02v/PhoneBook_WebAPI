using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook_webAPI.Other_entities_classes
{
    [Table(name: "Animal", Schema = "PhoneBook")]
    public class Animal
    {
        public string AnimalType { get; set; }
        public int AnimalId { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }

        public Animal() { }
        public Animal(string animalType)
        {
            AnimalType = animalType;
        }
    }
}
