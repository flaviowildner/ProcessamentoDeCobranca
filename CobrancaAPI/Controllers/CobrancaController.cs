using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CobrancaAPI.Models.DTO;
using CobrancaAPI.Models.Entity;
using CobrancaAPI.Models.Services;
using CobrancaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CobrancaAPI.Controllers
{
    [ApiController]
    [Route("/api/cobrancas")]
    public class CobrancaController : ControllerBase
    {
        private readonly ICobrancaService _cobrancaService;
        private readonly IMapper _mapper;

        public CobrancaController(ICobrancaService cobrancaService, IMapper mapper)
        {
            _cobrancaService = cobrancaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create cobrancas
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cobrancas
        ///     [{
        ///         "cpf": "100.268.579-60",
        ///         "valor": 1500,
        ///         "vencimento": "2020-04-03"
        ///     }]
        /// </remarks>
        /// <param name="cobrancaDtos">A list of clientes to be created.</param>
        [HttpPost]
        public async Task<IActionResult> CreateMany([FromBody] IEnumerable<CobrancaDTO> cobrancaDtos)
        {
            IEnumerable<Cobranca> cobrancas =
                _mapper.Map<IEnumerable<CobrancaDTO>, IEnumerable<Cobranca>>(cobrancaDtos);

            Task<CobrancaListResponse> task = _cobrancaService.CreateMany(cobrancas);

            return Ok("ok");
        }


        /// <summary>
        /// Get cobrancas
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/cobrancas
        ///     {
        ///         "cpf": "100.268.579-60",
        ///         "mes": 2020-12
        ///     }
        /// </remarks>
        /// <param name="cobrancaQuery">A dictionary containing the query filters, in which each entry is the type of filter and the value to be filtered.</param>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] IDictionary<string, string> cobrancaQuery)
        {
            CobrancaListResponse cobrancaListResponse = await _cobrancaService.Query(cobrancaQuery);

            if (!cobrancaListResponse.Success)
            {
                return BadRequest(new List<string> {cobrancaListResponse.Message});
            }

            IEnumerable<CobrancaDTO> cobrancas =
                _mapper.Map<IEnumerable<Cobranca>, IEnumerable<CobrancaDTO>>(cobrancaListResponse.Resource);

            return Ok(cobrancas);
        }
    }
}