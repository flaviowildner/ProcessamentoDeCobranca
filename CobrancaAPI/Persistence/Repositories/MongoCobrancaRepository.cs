using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CobrancaAPI.Models.Entity;
using CobrancaAPI.Persistence.Repositories.MongoDB;
using CobrancaAPI.Persistence.Repositories.MongoDB.FilterStrategies;
using CobrancaAPI.Settings;
using MongoDB.Driver;

namespace CobrancaAPI.Persistence.Repositories
{
    public class MongoCobrancaRepository : ICobrancaRepository
    {
        private readonly IMongoCollection<Cobranca> _cobrancas;
        private readonly IDictionary<string, IMongoFilterDefinitionStrategy<Cobranca>> _filterStrategies;

        public MongoCobrancaRepository(ICobrancaDatabaseSettings settings,
            IDictionary<string, IMongoFilterDefinitionStrategy<Cobranca>> filterStrategies)
        {
            MongoClient mongoClient = new MongoClient(settings.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(settings.DatabaseName);

            _cobrancas = mongoDatabase.GetCollection<Cobranca>(settings.CobrancaCollectionName);

            _filterStrategies = filterStrategies;
        }

        public Task Create(Cobranca cobranca)
        {
            return _cobrancas.InsertOneAsync(cobranca);
        }

        public async Task<IEnumerable<Cobranca>> Query(IDictionary<string, string> cobrancaQuery)
        {
            IList<FilterDefinition<Cobranca>> filterDefinitions = new List<FilterDefinition<Cobranca>>();

            foreach (KeyValuePair<string, string> filter in cobrancaQuery)
            {
                FilterDefinition<Cobranca> filterDefinition =
                    _filterStrategies[filter.Key].FilterDefinition(filter.Value);

                filterDefinitions.Add(filterDefinition);
            }

            FilterDefinition<Cobranca> filterDefinitionResult = filterDefinitions.Count > 0
                ? Builders<Cobranca>.Filter.And(filterDefinitions.AsEnumerable())
                : FilterDefinition<Cobranca>.Empty;

            IFindFluent<Cobranca, Cobranca> findFluent =
                _cobrancas.Find(filterDefinitionResult);

            return await Task.FromResult(findFluent.ToEnumerable());
        }
    }
}