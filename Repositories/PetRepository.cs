using Microsoft.EntityFrameworkCore;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.Other_entities_classes;

namespace PhoneBook_webAPI.Repositories
{
    public class PetRepository : DbRepository<Pet>, IPetRepository
    {
        public PetRepository(DataContext context) : base(context)
        {
        }
        public Pet ReadPet(int id)
        {
            var pet = _table
                .Where(x => x.PetId == id)
                .Include(pet => pet.Owner)
                .ThenInclude(owner => owner.Home)
                .Include(pet => pet.Animal)
                .FirstOrDefault();
            return pet;
        }

        public List<Pet> ReadPets()
        {
            var petList = _table
                .Include(pet => pet.Owner)
                .ThenInclude(owner => owner.Home)
                .Include(pet => pet.Animal)
                .ToList();
            return petList;
        }
    }
}