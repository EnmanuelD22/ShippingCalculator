namespace ShippingCalculator.Core.Entities
{
    public class Country
    {
        public int Id { get;  set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set;  } = string.Empty;
        public decimal RatePerKg { get; set; }
    }
}
