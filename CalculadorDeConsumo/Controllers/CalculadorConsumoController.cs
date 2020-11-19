using System.Threading.Tasks;
using CalculadorDeConsumo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadorDeConsumo.Controllers
{
    [ApiController]
    [Route("/calcula")]
    public class CalculadorDeConsumo : ControllerBase
    {
        private readonly ICalculadorDeConsumoService _calculadorDeConsumoService;

        public CalculadorDeConsumo(ICalculadorDeConsumoService calculadorDeConsumoService)
        {
            _calculadorDeConsumoService = calculadorDeConsumoService;
        }

        [HttpGet]
        public async Task<IActionResult> Calcula()
        {
            bool ok = await _calculadorDeConsumoService.Calcula();

            return Ok(ok);
        }
    }
}