using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;

namespace Multitenancy.SchemaVersioning
{
    public class TenantDbContext : EFCoreStoreDbContext<AppTenantInfo>
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("tenant-store");
            base.OnConfiguring(optionsBuilder);
        }
    }
}