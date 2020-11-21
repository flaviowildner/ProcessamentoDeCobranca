using System.Linq;

namespace ClienteAPI.Util.Validators
{
    public class CPFValidator : ICPFValidator
    {
        public bool IsValid(long cpf)
        {
            string cpfString = cpf.ToString(@"00000000000");

            if (string.IsNullOrWhiteSpace(cpfString) || cpfString.Length != 11)
                return false;

            var digits = new string(cpfString.Where(char.IsDigit).ToArray());
            if (digits.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == digits)
                    return false;


            int[] multiplier1 = {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplier2 = {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            string tempCpf = digits.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            string digit = mod.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            digit = digit + mod;

            return cpfString.EndsWith(digit);
        }
    }
}