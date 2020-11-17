using System.Collections.Generic;
using System.Threading.Tasks;
using CobrancaAPI.Models.Entity;

namespace CobrancaAPI.Persistence.Repositories
{
    public interface ICobrancaRepository
    {
        Task Create(Cobranca cobranca);

        Task<IEnumerable<Cobranca>> Query(IDictionary<string, string> cobrancaQuery);
    }
}