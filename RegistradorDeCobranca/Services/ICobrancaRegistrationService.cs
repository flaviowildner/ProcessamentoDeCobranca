using System.Threading.Tasks;

namespace RegistradorDeCobranca.Services
{
    public interface ICobrancaRegistrationService
    {
        Task<bool> Calcula();
    }
}