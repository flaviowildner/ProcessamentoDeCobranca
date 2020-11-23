using System;
using System.Threading.Tasks;
using RegistradorDeCobranca.Services;
using Microsoft.AspNetCore.Mvc;

namespace RegistradorDeCobranca.Controllers
{
    [ApiController]
    [Route("/api/registrador-cobranca")]
    public class RegistradorDeCobranca : ControllerBase
    {
        private readonly ICobrancaRegistrationService _cobrancaRegistrationService;

        public RegistradorDeCobranca(ICobrancaRegistrationService cobrancaRegistrationService)
        {
            _cobrancaRegistrationService = cobrancaRegistrationService;
        }

        [HttpPost]
        [Route("run")]
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