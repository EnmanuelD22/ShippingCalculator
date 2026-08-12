using ShippingCalculator.BusinessLogic.Interfaces;

namespace ShippingCalculator.BusinessLogic.Strategies
{
    public class UsRateStrategy : IShippingRateStrategy
    {
        public string CountryCode => "US";

        public decimal CalculateRate(decimal weight, decimal baseRate)
        {
            return weight * baseRate;
        }
    }
}
