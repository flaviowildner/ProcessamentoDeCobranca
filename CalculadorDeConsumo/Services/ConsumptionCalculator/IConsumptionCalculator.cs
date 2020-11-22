using ClienteAPI.Models.DTO;

namespace CalculadorDeConsumo.Services.ConsumptionCalculator
{
    public interface IConsumptionCalculator
    {
        decimal Calcula(ClienteDTO cliente);
    }
}