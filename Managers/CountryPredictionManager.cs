using PhoneBook_webAPI.ExternalProviders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PhoneBook_webAPI.Managers
{
    public class CountryPredictionManager(INationalizeProvider nationalizeProvider, IApiFirstProvider apiFirstProvider) : ICountryPredictionManager
    {
        private readonly INationalizeProvider _nationalizeProvider = nationalizeProvider;
        private readonly IApiFirstProvider _apiFirstProvider = apiFirstProvider;
        public async Task<List<CountryProbabilityViewModel>> GetProbabilities(string name)
        {
            var countryProbabilities = await _nationalizeProvider.GetCountryProbability(name);
            var listOfCountries = await _apiFirstProvider.ReadCountries();
            var countryProbabilityViewModels = new List<CountryProbabilityViewModel>();
            foreach (var country in countryProbabilities)
            {
                countryProbabilityViewModels.Add(new CountryProbabilityViewModel(country, listOfCountries[country.CountryId].CountryName));
            }
            return countryProbabilityViewModels;
        }
    }
}
