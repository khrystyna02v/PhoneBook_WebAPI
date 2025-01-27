using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.Data;

namespace PhoneBook_webAPI.Managers
{
    public class DbRepository<T>: IRepository<T> where T: class
    {
        private readonly DataContext _context;
        private DbSet<T> _table;
        public DbRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _table.ToList();
        }
        public T? GetById(int id)
        {
            return _table.Find(id);
        }

        public void Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();

        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(T oldEntity, T newEntity)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                    if (property.GetValue(newEntity) != null)
                    {
                        property.SetValue(oldEntity, property.GetValue(newEntity));
                    }
            }
            _context.SaveChanges();
        }

    }
}
