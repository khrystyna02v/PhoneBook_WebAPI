using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using PhoneBook_webAPI.Other_entities_classes;
using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Repositories
{
    public interface IPersonRepository: IRepository<Person>
    {
        OwnerViewModel ReadPetOwner(int id);
        List<Person> GetAll(Expression<Func<Person, bool>>? predicate = null);
        List<Person> GetAll(int skip, int take, Expression<Func<Person, bool>>? predicate = null);
        Person Get(Expression<Func<Person, bool>>? predicate = null);
    }
}
