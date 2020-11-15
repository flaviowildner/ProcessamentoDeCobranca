using ClienteAPI.Util;
using Xunit;

namespace ClienteAPI.Test.Util
{
    public class CPFValidatorTest
    {
        private readonly CPFValidator _cpfValidator;
        
        public CPFValidatorTest()
        {
            _cpfValidator = new CPFValidator();
        }
        

        [Fact]
        public void testValidFormat()
        {
            Assert.True(_cpfValidator.IsValid("255.305.154-95"));
        }
        
        
        [Theory]
        [InlineData("11111111111")]
        [InlineData("25530515495")]
        [InlineData("111.111.111.11")]
        [InlineData("111111111-11")]
        [InlineData("111.111.11111")]
        [InlineData("255.305.154-9545")]
        [InlineData("055-305-154-95")]
        [InlineData("1.1.1-2")]
        public void testInvalidFormat(string cpf)
        {
            Assert.False(_cpfValidator.IsValid(cpf));   
        }

        [Theory]
        [InlineData("111.111.111-11")]
        [InlineData("123.456.789-10")]
        public void testInvalidSequence(string cpf)
        {
            Assert.False(_cpfValidator.IsValid(cpf));
        }
    }
}