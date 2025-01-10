using System.Net.Http;
using System.Text.RegularExpressions;
using Azure;
using Microsoft.AspNetCore.Http.HttpResults;


namespace PhoneBook_webAPI
{
    public static class Functions
    {
        public static bool CheckPhoneNumber(string? number)
        {
            if (number == null) return false;
            var match = Regex.Match(number, @"^0[0-9]{9}$");
            return match.Success;
        }
        public static bool CheckName(string? name)
        {
            if (name == null) return false;
            var match = Regex.Match(name, @"^[A-Z]([a-z]+)((\-[A-Z][a-z]+)*)$");
            return match.Success;
        }
        public static bool CheckPartOfName(string? name)
        {
            if (name == null) return false;
            var match = Regex.Match(name, @"^[A-Z]([a-z]*)((\-[A-Z][a-z]+)*)$");
            return match.Success;
        }
        public static bool CheckEmail(string? email)
        {
            if (email == null) return false;
            var match = Regex.Match(email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9\-]+)\.([a-z]{2,5})(\s*)$");
            return match.Success;
        }
        public static bool CheckPerson(Person person)
        {
            return CheckName(person.Name) && CheckName(person.Surname) && CheckPhoneNumber(person.PhoneNumber);
        }

        public static void SortBook(List<Person> phoneBook)
        {
            phoneBook.Sort((person1, person2) => (person1.Name + " " + person1.Surname).CompareTo(person2.Name + " " + person2.Surname));
        }
        public static bool IsInBook(List<Person> phoneBook, string? name, string? surname)
        {
            var found = false;
            foreach (var person in phoneBook)
            {
                if (name == person.Name && surname == person.Surname) { found = true; break; }
            }
            return found;
        }
        public static Person? Find(List<Person> phoneBook, string? name, string? surname)
        {
            return phoneBook.Find(person => person.Name == name && person.Surname == surname);
        }
    }
}

