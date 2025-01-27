using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.Data;
using PhoneBook_webAPI.Managers;
using PhoneBook_webAPI.PersonClasses;

namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryPredictionController(IRepository<Person> manager, INationalizeProvider nationalizeProvider, ICountryPredictionManager countryPredictionManager, DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        private readonly IRepository<Person> _manager = manager;
        private readonly ICountryPredictionManager _countryPredictionManager = countryPredictionManager;

        [HttpGet("pedict-country")]
        public async Task<IActionResult> Predict(int id)
        {
            var phoneBook = _manager.GetAll();
            string name = "";
            foreach (var person in phoneBook)
            {
                if (person.PersonId == id)
                {
                    name = person.Name.ToLower();
                    break;
                }
            }
            if (name == "")
            {
                return NotFound("Person not found");
            }
            var countryProbabilitiesVM = _countryPredictionManager.GetProbabilities(name);
            return Ok(await countryProbabilitiesVM);
        }
    }
}
