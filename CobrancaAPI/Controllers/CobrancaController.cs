using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CobrancaAPI.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CobrancaDTO cobrancaParams)
        {
            Cobranca cobranca = _mapper.Map<CobrancaDTO, Cobranca>(cobrancaParams);

            CobrancaResponse cobrancaResponse = await _cobrancaService.Create(cobranca);

            if (!cobrancaResponse.Success)
            {
                return BadRequest(new List<string> {cobrancaResponse.Message});
            }

            return Ok(cobrancaParams);
        }

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