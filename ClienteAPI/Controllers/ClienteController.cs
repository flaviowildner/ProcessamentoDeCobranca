using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClienteAPI.Services;
using ClienteAPI.Util;
using ClienteAPI.Models.DTO;
using ClienteAPI.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDto);
            await _clienteService.AddAsync(cliente);

            return Ok(clienteDto);
        }

        [HttpGet]
        [Route("find")]
        public async Task<ClienteDTO> Get([FromQuery] [CPFValidator] string cpf)
        {
            long longCpf = _cpfFormatter.ToLong(cpf);
            Cliente cliente = await _clienteService.FindByCpf(longCpf);

            return _mapper.Map<Cliente, ClienteDTO>(cliente);
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> ListAsync()
        {
            IEnumerable<Cliente> clientes = await _clienteService.ListAsync();

            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(clientes);
        }
    }
}