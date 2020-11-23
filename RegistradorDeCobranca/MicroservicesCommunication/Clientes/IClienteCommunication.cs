using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Models.DTO;

namespace RegistradorDeCobranca.MicroservicesCommunication.Clientes
{
    public interface IClienteCommunication
    {
        Task<IEnumerable<ClienteDTO>> GetAllClientes();
    }
}