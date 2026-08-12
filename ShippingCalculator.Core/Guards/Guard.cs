using ShippingCalculator.Core.Exceptions;
namespace ShippingCalculator.Core.Guards
{
    public static class Guard
    {
        public static void AgainstNullOrEmpty(string? value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new BusinessException($"El campo '{fieldName}' es obligatorio.");
            }
        }

        public static void AgainstNegativeOrZero(decimal value, string fieldName)
        {
            if (value <= 0)
            {
                throw new BusinessException($"El valor de '{fieldName}' debe ser mayor a cero.");
            }
        }
    }
}
