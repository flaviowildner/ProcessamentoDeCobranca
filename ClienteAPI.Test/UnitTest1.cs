using AutoMapper;
using ClienteAPI.Models.DTO;
using ClienteAPI.Models.Entity;
using ClienteAPI.Util;
using Xunit;

namespace ClienteAPI.Test
{
    public class UnitTest1
    {
        [Fact]
        public void test()
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteDTO, Cliente>()
                .ForMember(dst => dst.Cpf,
                    opt => opt.ConvertUsing(new CPFValueConverter(new CPFFormatter()), src => src.Cpf));
            });

            Mapper mapper = new Mapper(configuration);

            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.Cpf = "158.654.317-22";
            clienteDTO.Nome = "Flavio";
            clienteDTO.Estado = "RJ";

            Cliente cliente = mapper.Map<ClienteDTO, Cliente>(clienteDTO);

            Assert.Equal(15865431722L, cliente.Cpf);
        }
    }
}