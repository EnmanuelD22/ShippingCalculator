using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShippingCalculator.BusinessLogic.Interfaces;
using ShippingCalculator.Core.Exceptions;
using ShippingCalculator.Web.Models;
using System;
using System.Threading.Tasks;

namespace ShippingCalculator.Web.Controllers
{
    public class TariffController : Controller
    {
        private readonly ITariffCalculator _tariffService;
        private readonly ILogger<TariffController> _logger;

        public TariffController(ITariffCalculator tariffService, ILogger<TariffController> logger)
        {
            _tariffService = tariffService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new TariffFormViewModel();

            try
            {
                _logger.LogInformation("Cargando la vista inicial y consultando los países disponibles.");
                viewModel.AvailableCountries = await _tariffService.GetAvailableCountriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al intentar cargar la lista de países al iniciar la vista.");
                viewModel.ErrorMessage = "No se pudieron cargar los destinos disponibles. Por favor, verifique la conexión e intente recargar la página.";
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TariffFormViewModel model)
        {
            try
            {
                _logger.LogInformation("Procesando solicitud de cálculo web para el destino: {Destino}", model.SelectedCountryCode);

                // Recargamos los países utilizando únicamente la capa de servicio de negocio
                model.AvailableCountries = await _tariffService.GetAvailableCountriesAsync();

                model.Result = await _tariffService.CalculateShippingAsync(model.SelectedCountryCode, model.Weight);
            }
            catch (BusinessException ex)
            {
                _logger.LogWarning("El cálculo fue rechazado por reglas de negocio: {Motivo}", ex.Message);
                model.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error no controlado en el controlador web.");
                model.ErrorMessage = "Ocurrió un error inesperado al procesar su solicitud. Intente más tarde.";
            }

            return View(model);
        }
    }
}