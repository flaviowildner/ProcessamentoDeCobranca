using ClienteAPI.Models.DTO;

namespace RegistradorDeCobranca.Services.ConsumptionCalculator
{
    public class CpfBasedConsumptionCalculator : IConsumptionCalculator
    {
        public decimal Calcula(ClienteDTO cliente)
        {
            string cpf = cliente.Cpf;

            int cpfLength = cpf.Length;
            if (cpfLength < 4)
            {
                return 0;
            }

            char[] chars = {cpf[0], cpf[1], cpf[cpfLength - 2], cpf[cpfLength - 1]};
            return decimal.Parse(chars);
        }
    }
}