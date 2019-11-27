using Finbuckle.MultiTenant.Stores;

namespace Multitenancy.SchemaVersioning
{
    public class AppTenantInfo : IEFCoreStoreTenantInfo
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}