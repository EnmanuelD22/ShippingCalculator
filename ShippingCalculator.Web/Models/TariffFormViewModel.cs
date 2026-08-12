using ShippingCalculator.BusinessLogic.DTOs;
using ShippingCalculator.Core.Entities;

namespace ShippingCalculator.Web.Models
{
    public class TariffFormViewModel
    {
        public string SelectedCountryCode { get; set; } = string.Empty;
        public decimal Weight { get; set; }

        public IEnumerable<Country> AvailableCountries { get; set; } = new List<Country>();

        public TariffResultDto? Result { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
