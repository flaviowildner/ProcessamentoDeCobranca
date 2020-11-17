using AutoMapper;
using CobrancaAPI.Models;
using CobrancaAPI.Models.DTO;
using CobrancaAPI.Models.Entity;

namespace CobrancaAPI.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cobranca, CobrancaDTO>();
            CreateMap<CobrancaDTO, Cobranca>();
        }
    }
}