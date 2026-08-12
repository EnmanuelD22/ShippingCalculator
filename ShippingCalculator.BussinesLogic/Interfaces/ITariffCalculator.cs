using ShippingCalculator.BusinessLogic.DTOs;
using ShippingCalculator.Core.Entities;

namespace ShippingCalculator.BusinessLogic.Interfaces
{
    public interface ITariffCalculator
    {
        Task<TariffResultDto> CalculateShippingAsync(string countryCode, decimal weight);
        Task<IEnumerable<Country>> GetAvailableCountriesAsync();
    }
}
