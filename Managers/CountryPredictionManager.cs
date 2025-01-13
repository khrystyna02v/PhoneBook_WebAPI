using PhoneBook_webAPI.ExternalProviders;

namespace PhoneBook_webAPI.Managers
{
    public class CountryPredictionManager(INationalizeProvider nationalizeProvider, IRestCountriesProvider restCountriesProvider) : ICountryPredictionManager
    {
        private readonly INationalizeProvider _nationalizeProvider = nationalizeProvider;
        private readonly IRestCountriesProvider _restCountriesProvider = restCountriesProvider;
        public async Task<List<CountryProbabilityViewModel>> GetProbabilities(string name)
        {
            var countryProbabilities = await _nationalizeProvider.GetCountryProbability(name);
            var countryProbabilityViewModels = new List<CountryProbabilityViewModel>();
            foreach (var country in countryProbabilities)
            {
                var countryName = _restCountriesProvider.GetCountryName(country.CountryId);
                var capital = _restCountriesProvider.GetCapital(country.CountryId);
                countryProbabilityViewModels.Add(new CountryProbabilityViewModel(country, await countryName, await capital));
            }
            return countryProbabilityViewModels;
        }
    }
}
