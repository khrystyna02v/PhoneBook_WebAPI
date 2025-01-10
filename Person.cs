namespace PhoneBook_webAPI
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Person() { }
        public Person(string name, string surname, string phoneNumber, string? email = null)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Person(PersonViewModel person)
        {
            Name = person.Name;
            Surname = person.Surname;
            PhoneNumber = person.PhoneNumber;
            Email = person.Email;
        }
    }
}
