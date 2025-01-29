using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.Other_entities_classes;
using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Repositories
{
    public class PersonRepository : DbRepository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }

        public List<Person> GetAll(Expression<Func<Person, bool>>? predicate = null)
        {
            IQueryable<Person> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = query
                .Include(person => person.Home);
            return query.ToList();
        }

        public List<Person> GetAll(int skip, int take, Expression<Func<Person, bool>>? predicate = null)
        {
            IQueryable<Person> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = query
                .Skip(skip)
                .Take(take)
                .Include(person => person.Home);
            return query.ToList();
        }

        public Person Get(Expression<Func<Person, bool>>? predicate = null)
        {
            IQueryable<Person> query = _table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            query = query.Include(person => person.Home);
            return query.FirstOrDefault();
        }

        public OwnerViewModel ReadPetOwner(int id)
        {
            var owner = _table
                .Where(x => x.PersonId == id)
                .Include(person => person.Pets)
                .ThenInclude(pet => pet.Animal)
                .FirstOrDefault();

            if (owner != null)
            {
                return new OwnerViewModel(owner);
            }
            return null;
        }
    }
}
