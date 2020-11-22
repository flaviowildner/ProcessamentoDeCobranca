using System.Collections.Generic;
using System.Threading.Tasks;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.MicroservicesCommunication.Cobrancas
{
    public interface ICobrancaCommunication
    {
        Task<bool> CreateCobrancaBatch(IEnumerable<CobrancaDTO> cobrancas);
    }
}