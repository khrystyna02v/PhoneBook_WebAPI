using System.Text.Json;

namespace PhoneBook_webAPI.Managers
{
    public class JsonManager : CommonManagerFunctions, IManager
    {
        public JsonManager(string _source = "Book2.json") : base(_source) {}
        public List<Person> Read()
        {
            CreateFileIfNotExists();
            var json = File.ReadAllText(_source);
            return JsonSerializer.Deserialize<List<Person>>(json);
        }
        public void Add(Person person)
        {
            var phoneBook = Read();
            phoneBook.Add(person);
            Rewrite(phoneBook);
        }
        public void Delete(string name, string surname)
        {
            var phoneBook = Read();
            var personToDelete = Functions.Find(phoneBook, name, surname);
            phoneBook.Remove(personToDelete);
            Rewrite(phoneBook);
        }
        public void Rewrite(List<Person> phoneBook)
        {
            Functions.SortBook(phoneBook);
            string updatedJson = JsonSerializer.Serialize(phoneBook, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_source, updatedJson);
        }
    }
}

