using System.Collections.Generic;
using System.Threading.Tasks;
using CobrancaAPI.Models.Entity;
using CobrancaAPI.Models.Services;

namespace CobrancaAPI.Services
{
    public interface ICobrancaService
    {
        Task<CobrancaResponse> Create(Cobranca cobranca);

        Task<CobrancaListResponse> CreateMany(IEnumerable<Cobranca> cobrancas);

        Task<CobrancaListResponse> Query(IDictionary<string, string> cobrancaQuery);
    }
}