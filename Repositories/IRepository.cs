using System.Linq.Expressions;

namespace PhoneBook_webAPI.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
        List<T> GetAll(int skip, int take, Expression<Func<T, bool>>? predicate = null);
        T Get(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? includes = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T oldEntity, T newEntity);

        //List<Person> Read();
        //void Add(Person person);
        //void Rewrite(List<Person> phoneBook);
        //void Delete(Person personToDelete);
    }
}
