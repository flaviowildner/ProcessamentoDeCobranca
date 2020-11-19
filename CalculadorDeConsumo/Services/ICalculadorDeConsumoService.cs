using System.Threading.Tasks;

namespace CalculadorDeConsumo.Services
{
    public interface ICalculadorDeConsumoService
    {
        Task<bool> Calcula();
    }
}