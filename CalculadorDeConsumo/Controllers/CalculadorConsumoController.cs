using System;
using System.Threading.Tasks;
using CalculadorDeConsumo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadorDeConsumo.Controllers
{
    [ApiController]
    [Route("/api/calculador-consumo")]
    public class CalculadorDeConsumo : ControllerBase
    {
        private readonly ICobrancaRegistrationService _cobrancaRegistrationService;

        public CalculadorDeConsumo(ICobrancaRegistrationService cobrancaRegistrationService)
        {
            _cobrancaRegistrationService = cobrancaRegistrationService;
        }

        [HttpPost]
        [Route("calcula")]
        public async Task<IActionResult> Calcula()
        {
            try
            {
                return Ok(await _cobrancaRegistrationService.Calcula());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}