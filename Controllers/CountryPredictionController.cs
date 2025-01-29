using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.Managers;
using PhoneBook_webAPI.Repositories;

namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryPredictionController(IPersonRepository manager, ICountryPredictionManager countryPredictionManager) : Controller
    {
        private readonly IPersonRepository _manager = manager;
        private readonly ICountryPredictionManager _countryPredictionManager = countryPredictionManager;

        [HttpGet("pedict-country")]
        public async Task<IActionResult> Predict(int id)
        {
            var person = _manager.Get(x => x.PersonId == id);
            if (person == null)
            {
                return NotFound("Person not found");
            }
            var countryProbabilitiesVM = _countryPredictionManager.GetProbabilities(person.Name.ToLower());
            return Ok(await countryProbabilitiesVM);
        }
    }
}
