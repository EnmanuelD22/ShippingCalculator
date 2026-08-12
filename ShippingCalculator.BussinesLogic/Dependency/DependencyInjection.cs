using Microsoft.Extensions.DependencyInjection;
using ShippingCalculator.BusinessLogic.Interfaces;
using ShippingCalculator.BusinessLogic.Services;
using ShippingCalculator.BusinessLogic.Strategies;

namespace ShippingCalculator.BusinessLogic.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            // Servicios Orquestadores
            services.AddScoped<ITariffCalculator, TariffCalculator>();

            // Estrategias de Cálculo por País
            services.AddScoped<IShippingRateStrategy, IndiaRateStrategy>();
            services.AddScoped<IShippingRateStrategy, UsRateStrategy>();
            services.AddScoped<IShippingRateStrategy, UkRateStrategy>();

            return services;
        }
    }
}