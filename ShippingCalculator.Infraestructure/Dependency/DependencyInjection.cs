using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShippingCalculator.Core.Interfaces;
using ShippingCalculator.Data.Context;
using ShippingCalculator.Data.Persistence.Repositories;

namespace ShippingCalculator.Data.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShippingDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //Registrar Repositorios
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }
    }
}
