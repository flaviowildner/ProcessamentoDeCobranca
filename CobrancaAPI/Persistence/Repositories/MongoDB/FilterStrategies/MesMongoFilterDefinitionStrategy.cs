using System;
using System.Globalization;
using CobrancaAPI.Models.Entity;
using MongoDB.Driver;

namespace CobrancaAPI.Persistence.Repositories.MongoDB.FilterStrategies
{
    public class MesMongoFilterDefinitionStrategy : IMongoFilterDefinitionStrategy<Cobranca>
    {
        public FilterDefinition<Cobranca> FilterDefinition(string value)
        {
            DateTime dateValue = DateTime.ParseExact(value, "yyyy-MM", CultureInfo.InvariantCulture);
            DateTime startDate = new DateTime(dateValue.Year, dateValue.Month, 1);
            DateTime endDate = new DateTime(dateValue.Year, dateValue.Month + 1, 1);
            return Builders<Cobranca>.Filter.Gte(cobranca => cobranca.Vencimento, startDate) &
                   Builders<Cobranca>.Filter.Lt(cobranca => cobranca.Vencimento, endDate);
        }
    }
}