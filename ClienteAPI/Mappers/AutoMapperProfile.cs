using AutoMapper;
using ClienteAPI.Util;
using ClienteAPI.Models.DTO;
using ClienteAPI.Models.Entity;

namespace ClienteAPI.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(ICPFFormatter cpfFormatter)
        {
            CPFValueConverter cpfValueConverter = new CPFValueConverter(cpfFormatter);

            CreateMap<Cliente, ClienteDTO>()
                .ForMember(src => src.Cpf,
                    opt => opt.ConvertUsing(cpfValueConverter, src => src.Cpf));

            CreateMap<ClienteDTO, Cliente>()
                .ForMember(src => src.Cpf,
                    opt => opt.ConvertUsing(cpfValueConverter, src => src.Cpf));
        }
    }
}