namespace PhoneBook_webAPI.Other_entities_classes
{
    public class PetViewModel
    {
        public int? PetId { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        
        public PetViewModel(Pet pet)
        {
            PetId = pet.PetId;
            Name = pet.Name;
            AnimalType = pet.Animal.AnimalType;
        }
    }
}
