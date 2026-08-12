
using ShippingCalculator.BusinessLogic.Interfaces;

namespace ShippingCalculator.BusinessLogic.Strategies
{
    public class UkRateStrategy : IShippingRateStrategy
    {
        public string CountryCode => "UK";

        public decimal CalculateRate(decimal weight, decimal baseRate)
        {
            return weight * baseRate;
        }
    }
}
