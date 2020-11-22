using System.Threading.Tasks;

namespace CalculadorDeConsumo.Services
{
    public interface ICobrancaRegistrationService
    {
        Task<bool> Calcula();
    }
}