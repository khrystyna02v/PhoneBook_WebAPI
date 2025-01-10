using PhoneBook_webAPI.ExternalProviders;

namespace PhoneBook_webAPI.Managers
{
    public class CountryPredictionManager(INationalizeProvider nationalizeProvider, IApiFirstProvider apiFirstProvider, IRestCountriesProvider restCountriesProvider) : ICountryPredictionManager
    {
        private readonly INationalizeProvider _nationalizeProvider = nationalizeProvider;
        private readonly IApiFirstProvider _apiFirstProvider = apiFirstProvider;
        private readonly IRestCountriesProvider _restCountriesProvider = restCountriesProvider;
        public async Task<List<CountryProbabilityViewModel>> GetProbabilities(string name)
        {
            var countryProbabilities = await _nationalizeProvider.GetCountryProbability(name);
            var listOfCountries = await _apiFirstProvider.ReadCountries();
            var countryProbabilityViewModels = new List<CountryProbabilityViewModel>();
            foreach (var country in countryProbabilities)
            {
                var capital = _restCountriesProvider.GetCapital(country.CountryId);
                countryProbabilityViewModels.Add(new CountryProbabilityViewModel(country, listOfCountries[country.CountryId].CountryName, await capital));
            }
            return countryProbabilityViewModels;
        }
    }
}
