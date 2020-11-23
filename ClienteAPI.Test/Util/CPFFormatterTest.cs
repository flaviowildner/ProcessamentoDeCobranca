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
        
        
        [Fact]
        public void TestToLong()
        {
            Assert.Equal(25530515495, _cpfFormatter.ToLong("255.305.154-95"));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123.321.32123")]
        [InlineData("123321321-23")]
        [InlineData("123.321321-23")]
        [InlineData("123321.321-23")]
        public void TestInvalid(string cpf)
        {
            Assert.Equal(-1, _cpfFormatter.ToLong(cpf));
        }
    }
}