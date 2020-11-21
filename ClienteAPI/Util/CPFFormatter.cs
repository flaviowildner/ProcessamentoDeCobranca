using System.Collections.Generic;
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
                return 0;

            string digits = new string(cpf.Where(char.IsDigit).ToArray());

            if (digits.Length == 0)
                return 0;

            return long.Parse(digits);
        }
    }
}