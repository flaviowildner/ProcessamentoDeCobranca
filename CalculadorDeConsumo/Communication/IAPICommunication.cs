using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Communication
{
    public interface IAPICommunication
    {
        Task<IEnumerable<ClienteDTO>> GetClientes();

        Task<bool> CreateCobrancaBatch(IEnumerable<CobrancaDTO> cobrancas);
    }
}