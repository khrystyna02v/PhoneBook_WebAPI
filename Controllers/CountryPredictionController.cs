using Microsoft.AspNetCore.Mvc;
using PhoneBook_webAPI.Managers;

namespace PhoneBook_webAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryPredictionController(IManager manager, INationalizeProvider nationalizeProvider, IApiFirstProvider apiFirstProvider, ICountryPredictionManager countryPredictionManager) : Controller
    {
        private readonly IManager _manager = manager;
        private readonly ICountryPredictionManager _countryPredictionManager = countryPredictionManager;

        [HttpGet("pedict-country")]
        public async Task<IActionResult> Predict(int number)
        {
            var phoneBook = _manager.Read();
            if (number > phoneBook.Count || number <= 0)
            {
                return BadRequest();
            }
            var name = phoneBook[number - 1].Name.ToLower();

            var countryProbabilitiesVM = _countryPredictionManager.GetProbabilities(name);
            return Ok(await countryProbabilitiesVM);
        }
    }
}
