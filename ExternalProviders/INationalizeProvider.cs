using PhoneBook_webAPI.CountryPredictionClasses;

namespace PhoneBook_webAPI
{
    public interface INationalizeProvider
    {
        Task<List<CountryProbability>> GetCountryProbability(string name);
    }
}
