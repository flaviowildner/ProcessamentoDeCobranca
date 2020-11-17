using CobrancaAPI.Models.Entity;

namespace CobrancaAPI.Models.Services
{
    public class CobrancaResponse : BaseResponse<Cobranca>
    {
        public CobrancaResponse(Cobranca resource) : base(resource)
        {
        }

        public CobrancaResponse(string message) : base(message)
        {
        }
    }
}