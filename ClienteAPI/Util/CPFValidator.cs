using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClienteAPI.Util
{
    public class CPFValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null || value is not string)
            {
                return false;
            }

            string cpf = (string) value;

            if (string.IsNullOrWhiteSpace(cpf) || (cpf.Length != 11 && cpf.Length != 14))
                return false;

            if (cpf.Length == 14 && (cpf[3] != '.' || cpf[7] != '.' || cpf[11] != '-'))
                return false;

            var digits = new string(cpf.Where(char.IsDigit).ToArray());

            if (digits.Length != 11)
                return false;

            var verifiers = digits.Substring(9, 2);

            var actualNumber = digits.Substring(0, 9);

            var verifier1 = Mod11(actualNumber);

            if (verifier1 != verifiers[0])
                return false;

            actualNumber += verifier1;

            var verifier2 = Mod11(actualNumber);

            return verifier2 == verifiers[1];
        }

        private static char Mod11(string number)
        {
            var sum = 0;

            for (int i = number.Length - 1, multiplier = 2; i >= 0; --i, ++multiplier)
                sum += int.Parse(number[i].ToString()) * multiplier;

            var mod11 = sum % 11;
            return mod11 < 2 ? '0' : (11 - mod11).ToString()[0];
        }
    }
}