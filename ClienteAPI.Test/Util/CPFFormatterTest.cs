using ClienteAPI.Util;
using Xunit;

namespace ClienteAPI.Test.Util
{
    public class CPFFormatterTest
    {
        private readonly ICPFFormatter _cpfFormatter;

        public CPFFormatterTest()
        {
            _cpfFormatter = new CPFFormatter();
        }
        
        
        [Theory]
        [InlineData("255.305.154-95")]
        [InlineData("25530515495")]
        public void TestToLong(string cpf)
        {
            Assert.Equal(25530515495, _cpfFormatter.ToLong(cpf));
        }
    }
}