using Microsoft.Extensions.Logging;
using ShippingCalculator.BusinessLogic.DTOs;
using ShippingCalculator.BusinessLogic.Interfaces;
using ShippingCalculator.Core.Entities;
using ShippingCalculator.Core.Exceptions;
using ShippingCalculator.Core.Guards;
using ShippingCalculator.Core.Interfaces;

namespace ShippingCalculator.BusinessLogic.Services
{
    public class TariffCalculator : ITariffCalculator
    {
        private readonly ICountryRepository _repository;
        private readonly IEnumerable<IShippingRateStrategy> _strategies;
        private readonly ILogger<TariffCalculator> _logger;


        public TariffCalculator(ICountryRepository repository, IEnumerable<IShippingRateStrategy> strategies,
            ILogger<TariffCalculator> logger)
        {
            _repository = repository;
            _strategies = strategies;
            _logger = logger;
        }

        public async Task<IEnumerable<Country>> GetAvailableCountriesAsync()
        {
            try
            {
                _logger.LogInformation("Consultando el listado de países disponibles desde el repositorio.");
                return await _repository.GetAllCountriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de países desde la base de datos.");
                throw;
            }
        }

        public async Task<TariffResultDto> CalculateShippingAsync(string countryCode, decimal weight)
        {
            try
            {
                _logger.LogInformation("Iniciando cálculo de tarifa para el país: {CountryCode} con peso: {weight} Kg", countryCode, weight);
                Guard.AgainstNegativeOrZero(weight, "Peso del Paquete");
                Guard.AgainstNullOrEmpty(countryCode, "País de Destino");

                var country = await _repository.GetCountryByCodeAsyn(countryCode);

                if (country == null)
                {
                    _logger.LogWarning("El país con código {CountryCode} no fue encontrado.", countryCode);
                    throw new BusinessException("El destino seleccionado no está configurado en el sistema.");
                }

                var strategy = _strategies.FirstOrDefault(s => s.CountryCode == countryCode);

                if (strategy == null)
                {
                    _logger.LogError("Estrategia no implementada para el país: {CountryName}", country.Name);
                    throw new BusinessException($"No hay regla de cálculos configurada para {country.Name}.");
                }

                decimal finalCost = strategy.CalculateRate(weight, country.RatePerKg);
                _logger.LogInformation("Cálculo exitoso para {CountryCode}. Total: {Total} USD", countryCode, finalCost);

                return new TariffResultDto
                {
                    CountryName = country.Name,
                    Weight = weight,
                    TotalCost = finalCost
                };

            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al calcular la tarifa para {CountryCode}", countryCode);
                throw new Exception("Ocurrió un error interno en el servidor. Por favor, intente más tarde.");
            }
        }
    }
}
