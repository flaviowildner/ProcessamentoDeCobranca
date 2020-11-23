using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClienteAPI.Services;
using ClienteAPI.Util;
using ClienteAPI.Models.DTO;
using ClienteAPI.Models.Entity;
using ClienteAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("/api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        private readonly ICPFFormatter _cpfFormatter;

        public ClienteController(IClienteService clienteService, IMapper mapper, ICPFFormatter cpfFormatter)
        {
            _clienteService = clienteService;
            _mapper = mapper;
            _cpfFormatter = cpfFormatter;
        }

        /// <summary>
        /// Create a cliente
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/clientes
        /// 
        /// Sample response:
        ///
        ///     {
        ///         "cpf": "100.268.579-60",
        ///         "nome": "Fulano",
        ///         "estado": "RJ"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteParams)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteParams);
            ClienteResponse clienteResponse = await _clienteService.AddAsync(cliente);

            if (!clienteResponse.Success)
            {
                return BadRequest(clienteResponse.Message);
            }

            ClienteDTO clienteDto = _mapper.Map<Cliente, ClienteDTO>(clienteResponse.Resource);
            return Ok(clienteDto);
        }


        /// <summary>
        /// Get clientes
        /// </summary>
        /// 
        /// <remarks>
        /// By CPF sample request:
        ///
        ///     GET /api/clientes?cpf=100.268.579-60
        /// 
        /// By CPF sample response:
        ///
        ///     {
        ///         "cpf": "100.268.579-60",
        ///         "nome": "Fulano",
        ///         "estado": "RJ"
        ///     }
        ///
        /// Multiple clientes sample request:
        ///
        ///     GET /api/clientes?limit=2
        ///
        /// Multiple clientes sample request:
        ///
        ///     [
        ///         {
        ///             "cpf": "100.268.579-60",
        ///             "nome": "Fulano",
        ///             "estado": "RJ"
        ///         },
        ///         {
        ///             "cpf": "100.329.856-73",
        ///             "nome": "Ciclano",
        ///             "estado": "SP"
        ///         }
        ///     ]
        /// </remarks>
        /// <param name="cpf">The optional cpf filter</param>
        /// <param name="limit">An optional parameter to limit the number of entities returned.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cpf, int limit)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return await ListAsync(limit);
            }

            long longCpf = _cpfFormatter.ToLong(cpf);

            ClienteResponse clienteResponse = await _clienteService.FindByCpf(longCpf);
            if (!clienteResponse.Success)
            {
                return BadRequest(clienteResponse.Message);
            }

            ClienteDTO clienteDto = _mapper.Map<Cliente, ClienteDTO>(clienteResponse.Resource);
            return Ok(clienteDto);
        }

        private async Task<IActionResult> ListAsync(int limit)
        {
            ClienteListResponse clientes = await _clienteService.ListAsync(limit);

            return Ok(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(clientes.Resource));
        }
    }
}