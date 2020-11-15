using AutoMapper;
using ClienteAPI.Util;

namespace ClienteAPI.Mappers
{
    public class CPFValueConverter : IValueConverter<string, long>, IValueConverter<long, string>
    {
        private readonly ICPFFormatter _cpfFormatter;

        public CPFValueConverter(ICPFFormatter cpfFormatter)
        {
            _cpfFormatter = cpfFormatter;
        }

        public long Convert(string sourceMember, ResolutionContext context)
        {
            return _cpfFormatter.ToLong(sourceMember);
        }

        public string Convert(long sourceMember, ResolutionContext context)
        {
            return _cpfFormatter.ToString(sourceMember);
        }
    }
}