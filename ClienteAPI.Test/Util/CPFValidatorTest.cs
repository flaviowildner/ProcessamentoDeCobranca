using ClienteAPI.Util;
using ClienteAPI.Util.Validators;
using Xunit;

namespace ClienteAPI.Test.Util
{
    public class CPFValidatorTest
    {
        private readonly ICPFValidator _cpfValidator;

        public CPFValidatorTest()
        {
            _cpfValidator = new CPFValidator();
        }

        [Fact]
        public void TestValidFormat()
        {
            Assert.True(_cpfValidator.IsValid(255_305_154_95));
        }

        [Fact]
        public void TestValidCpfStartingWithZero()
        {
            Assert.True(_cpfValidator.IsValid(011_685_990_32));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(123456789123456)]
        public void TestCPfWithLengthDifferentOfEleven(long cpf)
        {
            Assert.False(_cpfValidator.IsValid(cpf));
        }

        [Theory]
        [InlineData(111_111_111_112)]
        [InlineData(123_456_789_10)]
        [InlineData(109_876_543_21)]
        public void TestInvalidSequences(long cpf)
        {
            Assert.False(_cpfValidator.IsValid(cpf));
        }
    }
}