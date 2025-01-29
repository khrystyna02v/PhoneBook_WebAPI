using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.Other_entities_classes;
using PhoneBook_webAPI.Repositories;

namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController (IPetRepository petManager, IAnimalRepository animalManager, IPersonRepository personManager) : Controller
    {
        private readonly IPetRepository _petManager = petManager;
        private readonly IAnimalRepository _animalManager = animalManager;
        private readonly IPersonRepository _personManager = personManager;


        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            return Ok(_petManager.ReadPets());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> Get(int id)
        {
            var pet = _petManager.ReadPet(id);
            if (pet != null)
            {
                return Ok(pet);
            }
            return NotFound("Pet not found");
        }

        [HttpGet("get-all-by-type")]
        public async Task<IActionResult> GetByType(int typeId)
        {
            var animal = _animalManager.ReadAnimals(typeId);
            if (animal != null)
            {
                return Ok(animal);
            }
            return NotFound("Animal type not found");
        }

        [HttpGet("get-by-owner-id")]
        public async Task<IActionResult> Pets(int id)
        {
            var owner = _personManager.ReadPetOwner(id);
            if (owner == null)
            {
                return NotFound("Person not found");
            }
            return Ok(owner);
        }
    }
}
