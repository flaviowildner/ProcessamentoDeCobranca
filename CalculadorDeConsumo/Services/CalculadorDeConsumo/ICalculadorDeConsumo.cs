using ClienteAPI.Models.DTO;

namespace CalculadorDeConsumo.Services.CalculadorDeConsumo
{
    public interface ICalculadorDeConsumo
    {
        decimal Calcula(ClienteDTO cliente);
    }
}