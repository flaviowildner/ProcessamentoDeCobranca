using System.Collections.Generic;
using System.Threading.Tasks;
using CobrancaAPI.Models.DTO;

namespace RegistradorDeCobranca.MicroservicesCommunication.Cobrancas
{
    public interface ICobrancaCommunication
    {
        Task<bool> CreateCobrancaBatch(IEnumerable<CobrancaDTO> cobrancas);
    }
}