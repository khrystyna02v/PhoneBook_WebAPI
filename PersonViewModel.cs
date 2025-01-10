namespace PhoneBook_webAPI
{
    public class PersonViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public PersonViewModel()
        {
            Name = "none";
            Surname = "none";
            PhoneNumber = "0000000000";
            Email = null;
        }
        public PersonViewModel(string name, string surname, string phoneNumber, string? email = null)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public PersonViewModel(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            PhoneNumber = person.PhoneNumber;
            Email = person.Email;
        }
    }
}
