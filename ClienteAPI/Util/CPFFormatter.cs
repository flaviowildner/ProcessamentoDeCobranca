using System.Linq;

namespace ClienteAPI.Util
{
    public class CPFFormatter : ICPFFormatter
    {
        public string ToString(long cpf)
        {
            return cpf.ToString(@"000\.000\.000\-00");
        }

        public long ToLong(string cpf)
        {
            if (cpf == null)
                return -1;

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 14)
                return -1;

            if (cpf[3] != '.' || cpf[7] != '.' || cpf[11] != '-')
                return -1;

            string digits = new string(cpf.Where(char.IsDigit).ToArray());

            if (digits.Length == 0)
                return -1;

            return long.Parse(digits);
        }
    }
}