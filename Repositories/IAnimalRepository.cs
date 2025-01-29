using PhoneBook_webAPI.Other_entities_classes;

namespace PhoneBook_webAPI.Repositories
{
    public interface IAnimalRepository: IRepository<Animal>
    {
        public List<Animal> ReadAnimals(int id);
    }
}
