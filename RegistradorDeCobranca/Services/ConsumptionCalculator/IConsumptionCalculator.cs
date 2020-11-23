using ClienteAPI.Models.DTO;

namespace RegistradorDeCobranca.Services.ConsumptionCalculator
{
    public interface IConsumptionCalculator
    {
        decimal Calcula(ClienteDTO cliente);
    }
}