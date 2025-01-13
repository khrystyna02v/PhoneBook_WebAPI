namespace PhoneBook_webAPI.ExternalProviders
{
    public interface IRestCountriesProvider
    {
        Task<string> GetCapital(string code);
        Task<string> GetCountryName(string code);
    }
}
