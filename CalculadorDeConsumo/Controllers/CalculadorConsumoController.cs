using System.Threading.Tasks;
using CalculadorDeConsumo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadorDeConsumo.Controllers
{
    [ApiController]
    [Route("/calcula")]
    public class CalculadorDeConsumo : ControllerBase
    {
        private readonly ICobrancaRegistrationService _cobrancaRegistrationService;

        public CalculadorDeConsumo(ICobrancaRegistrationService cobrancaRegistrationService)
        {
            _cobrancaRegistrationService = cobrancaRegistrationService;
        }

        [HttpGet]
        public async Task<IActionResult> Calcula()
        {
            bool ok = await _cobrancaRegistrationService.Calcula();

            return Ok(ok);
        }
    }
}