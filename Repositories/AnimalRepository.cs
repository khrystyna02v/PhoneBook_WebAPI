using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.Other_entities_classes;

namespace PhoneBook_webAPI.Repositories
{
    public class AnimalRepository : DbRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DataContext context) : base(context)
        {
        }
        public List<Animal> ReadAnimals(int id)
        {
            var pets = _table
                .Where(x => x.AnimalId == id)
                .Include(animal => animal.Pets)
                .ThenInclude(animal => animal.Owner)
                .ToList();
            return pets;
        }
    }
}
