using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook_webAPI.PersonClasses
{
    [Table(name: "Person", Schema = "PhoneBook")]
    public class Person
    {
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //public string? DateOfBirth { get; set; }
        public Person() { }
        public Person(int id, string name, string surname, string phoneNumber, DateTime? date, string? email = null)
        {
            PersonId = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = date;
        }
        public Person(string name, string surname, string phoneNumber, DateTime? date, string? email = null)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            DateOfBirth = date;
        }
        public Person(PersonViewModel person)
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
