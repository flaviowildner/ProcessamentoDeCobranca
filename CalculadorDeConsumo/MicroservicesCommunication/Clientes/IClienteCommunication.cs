using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Models.DTO;

namespace CalculadorDeConsumo.MicroservicesCommunication.Clientes
{
    public interface IClienteCommunication
    {
        Task<IEnumerable<ClienteDTO>> GetAllClientes();
    }
}