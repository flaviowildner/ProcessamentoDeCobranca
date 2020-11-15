using ClienteAPI.Models.Entity;

namespace ClienteAPI.Models.Services
{
    public class ClienteResponse : BaseResponse<Cliente>
    {
        public ClienteResponse(Cliente cliente) : base(cliente)
        {
        }

        public ClienteResponse(string message) : base(message)
        {
        }
    }
}