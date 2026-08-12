using ShippingCalculator.BusinessLogic.Interfaces;

namespace ShippingCalculator.BusinessLogic.Strategies
{
    public class IndiaRateStrategy : IShippingRateStrategy
    {
        public string CountryCode => "IN";

        public decimal CalculateRate(decimal weight, decimal baseRate)
        {
            return weight * baseRate;
        }
    }
}
