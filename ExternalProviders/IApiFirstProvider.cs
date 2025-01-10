using System.Net.Http;

namespace PhoneBook_webAPI
{
    public interface IApiFirstProvider
    {
        Task<Dictionary<string, CountryInfo>> ReadCountries();
    }
}
