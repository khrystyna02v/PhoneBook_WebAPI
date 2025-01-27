using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Managers
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T oldEntity, T newEntity);
        //List<Person> Read();
        //void Add(Person person);
        //void Rewrite(List<Person> phoneBook);
        //void Delete(Person personToDelete);
    }
}
