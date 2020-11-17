using MongoDB.Driver;

namespace CobrancaAPI.Persistence.Repositories.MongoDB.FilterStrategies
{
    public interface IMongoFilterDefinitionStrategy<T>
    {
        FilterDefinition<T> FilterDefinition(string value);
    }
}