using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace RegistradorDeCobranca.Infrastructure.Factories
{
    public interface ICobrancaFactory
    {
        CobrancaDTO Create();

        CobrancaDTO Create(ClienteDTO cliente);
    }
}