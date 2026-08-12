
namespace ShippingCalculator.BusinessLogic.DTOs
{
    public record TariffResultDto
    {
        public string CountryName { get; init; } = string.Empty;
        public decimal Weight { get; init; }
        public decimal TotalCost { get; init; }
    }
}
