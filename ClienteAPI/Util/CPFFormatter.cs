using System.Text;

namespace ClienteAPI.Util
{
    public class CPFFormatter : ICPFFormatter
    {
        public string ToString(long input)
        {
            return input.ToString(@"000\.000\.000\-00");
        }

        public long ToLong(string input)
        {
            StringBuilder longCpfBuilder = new StringBuilder(input.Trim());

            longCpfBuilder.Replace(",", "");
            longCpfBuilder.Replace(".", "");
            longCpfBuilder.Replace("-", "");

            return long.Parse(longCpfBuilder.ToString());
        }
    }
}