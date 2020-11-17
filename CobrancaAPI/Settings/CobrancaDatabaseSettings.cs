namespace CobrancaAPI.Settings
{
    public class CobrancaDatabaseSettings : ICobrancaDatabaseSettings
    {
        public string CobrancaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}