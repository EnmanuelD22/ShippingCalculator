
namespace ShippingCalculator.BusinessLogic.Interfaces
{
    public interface IShippingRateStrategy
    {
        string CountryCode { get; }
        decimal CalculateRate(decimal weight, decimal baseRate);
    }
}
