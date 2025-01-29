using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Other_entities_classes
{
    public class OwnerViewModel
    {
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<PetViewModel> Pets { get; set; }

        public OwnerViewModel(Person person)
        {
            PersonId = person.PersonId;
            Name = person.Name;
            Surname = person.Surname;
            Pets = person.Pets.Select(x => new PetViewModel(x)).ToList();
        }
    }
}
