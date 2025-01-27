namespace PhoneBook_webAPI.PersonClasses
{
    public class PersonViewModel
    {
        public int? PersonId;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public PersonViewModel()
        {
            Name = "none";
            Surname = "none";
            PhoneNumber = "0000000000";
            Email = null;
            DateOfBirth = null;
        }
        public PersonViewModel(string name, string surname, string phoneNumber, DateTime? date, string? email = null)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = date;
        }

        public PersonViewModel(Person person)
        {
            PersonId = person.PersonId;
            Name = person.Name;
            Surname = person.Surname;
            PhoneNumber = person.PhoneNumber;
            Email = person.Email;
            DateOfBirth = person.DateOfBirth;
        }
    }
}
