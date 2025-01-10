namespace PhoneBook_webAPI.Managers
{
    public interface ICountryPredictionManager
    {
        Task<List<CountryProbabilityViewModel>> GetProbabilities(string name);
    }
}
