using CobrancaAPI.Models.Entity;
using MongoDB.Driver;

namespace CobrancaAPI.Persistence.Repositories.MongoDB.FilterStrategies
{
    public class CpfMongoFilterDefinitionStrategy : IMongoFilterDefinitionStrategy<Cobranca>
    {
        public FilterDefinition<Cobranca> FilterDefinition(string value)
        {
            return Builders<Cobranca>.Filter.Eq(cobranca => cobranca.Cpf, value);
        }
    }
}