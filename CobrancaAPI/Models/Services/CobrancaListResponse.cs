using System.Collections.Generic;
using CobrancaAPI.Models.Entity;

namespace CobrancaAPI.Models.Services
{
    public class CobrancaListResponse : BaseResponse<IEnumerable<Cobranca>>
    {
        public CobrancaListResponse(IEnumerable<Cobranca> resource) : base(resource)
        {
        }

        public CobrancaListResponse(string message) : base(message)
        {
        }
    }
}