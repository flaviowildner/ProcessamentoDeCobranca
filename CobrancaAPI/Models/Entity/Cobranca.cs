using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CobrancaAPI.Models.Entity
{
    public class Cobranca
    {
        [BsonId]
        public ObjectId id;
        
        [BsonElement("cpf")]
        public string Cpf { get; set; }
        
        [BsonElement("valor")]
        public decimal Valor { get; set; }

        [BsonElement("vencimento")]
        public DateTime Vencimento { get; set; }
    }
}