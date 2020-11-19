using ClienteAPI.Models.DTO;

namespace CalculadorDeConsumo.Services.CalculadorDeConsumo
{
    public class CalculadorDeConsumoBaseadoNoCPF : ICalculadorDeConsumo
    {
        public decimal Calcula(ClienteDTO cliente)
        {
            string cpf = cliente.Cpf;

            string twoFirstDigits = cpf.Substring(0, 2);
            string twoLastDigits = cpf.Substring(cpf.Length - 2);

            return decimal.Parse(twoFirstDigits + twoLastDigits);
        }
    }
}