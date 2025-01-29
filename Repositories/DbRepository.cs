using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.Data;

namespace PhoneBook_webAPI.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        protected readonly DbSet<T> _table;
        public DbRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.ToList();
        }

        public List<T> GetAll(int skip, int take, Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = query.Skip(skip).Take(take);
            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? includes = null)
        {
            IQueryable<T> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includes != null)
            {
                query = query.Include(includes);
            }

            return query.FirstOrDefault();
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
