namespace PhoneBook_webAPI.Managers
{
    public interface IManager
    {
        List<Person> Read();
        void Add(Person person);
        void Rewrite(List<Person> phoneBook);
    }
}
