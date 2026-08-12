
using ShippingCalculator.Core.Entities;

namespace ShippingCalculator.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetCountryByCodeAsyn(string code);
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}
