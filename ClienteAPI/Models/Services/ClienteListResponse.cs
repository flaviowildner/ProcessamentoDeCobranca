using System.Collections.Generic;
using ClienteAPI.Models.Entity;

namespace ClienteAPI.Models.Services
{
    public class ClienteListResponse : BaseResponse<IEnumerable<Cliente>>
    {
        public ClienteListResponse(IEnumerable<Cliente> resource) : base(resource)
        {
        }

        public ClienteListResponse(string message) : base(message)
        {
        }
    }
}