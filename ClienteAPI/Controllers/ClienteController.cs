using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClienteAPI.Services;
using ClienteAPI.Util;
using ClienteAPI.Models.DTO;
using ClienteAPI.Models.Entity;
using ClienteAPI.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        public async Task<IActionResult> Create([FromBody] ClienteDTO clienteParams)
        {
            Cliente cliente = _mapper.Map<ClienteDTO, Cliente>(clienteParams);
            ClienteResponse clienteResponse = await _clienteService.AddAsync(cliente);

            if (!clienteResponse.Success)
            {
                ModelState.AddModelError(nameof(ClienteDTO.Cpf), "Duplicated CPF");
                return ValidationProblem();
            }

            ClienteDTO clienteDto = _mapper.Map<Cliente, ClienteDTO>(clienteResponse.Resource);
            return Ok(clienteDto);
        }

        [HttpGet]
        [Route("find")]
        public async Task<ClienteDTO> Get([FromQuery] [CPFValidator] string cpf)
        {
            long longCpf = _cpfFormatter.ToLong(cpf);

            ClienteResponse clienteResponse = await _clienteService.FindByCpf(longCpf);

            return _mapper.Map<Cliente, ClienteDTO>(clienteResponse.Resource);
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> ListAsync()
        {
            ClienteListResponse clientes = await _clienteService.ListAsync();

            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDTO>>(clientes.Resource);
        }

        public override ActionResult ValidationProblem()
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult) options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}