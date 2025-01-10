namespace PhoneBook_webAPI
{
    public interface INationalizeProvider
    {
        Task<List<CountryProbability>> GetCountryProbability(string name);
    }
}
