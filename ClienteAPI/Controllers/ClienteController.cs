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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return await ListAsync();
            }

            long longCpf = _cpfFormatter.ToLong(cpf);

            ClienteResponse clienteResponse = await _clienteService.FindByCpf(longCpf);

            return Ok(_mapper.Map<Cliente, ClienteDTO>(clienteResponse.Resource));
        }

        private async Task<IActionResult> ListAsync()
        {
            ClienteListResponse clientes = await _clienteService.ListAsync();

            return Ok(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(clientes.Resource));
        }
    }
}