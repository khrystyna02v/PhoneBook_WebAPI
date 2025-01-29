using PhoneBook_webAPI.Other_entities_classes;

namespace PhoneBook_webAPI.Repositories
{
    public interface IPetRepository: IRepository<Pet>
    {
        public Pet ReadPet(int id);
        public List<Pet> ReadPets();
    }
}
