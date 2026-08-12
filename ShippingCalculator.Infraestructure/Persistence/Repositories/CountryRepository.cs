using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShippingCalculator.Core.Entities;
using ShippingCalculator.Core.Interfaces;
using ShippingCalculator.Data.Context;

namespace ShippingCalculator.Data.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ShippingDbContext _context;
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(ShippingDbContext context, ILogger<CountryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            try
            {
                return await _context.Country.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al cargar países.");
                throw new Exception("Error al recuperar los destinos.");
            }
        }

        public async Task<Country?> GetCountryByCodeAsyn(string code)
        {
            try
            {
                _logger.LogInformation("Consultando a la base de datos para el país con código: {Code}", code);
                return await _context.Country.FirstOrDefaultAsync(c => c.Code == code);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar el país.");
                throw new Exception("Error al comunicarse con la base de datos.");
            }
        }


    }
}
