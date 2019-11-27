using Database.DoFactory;
using Database.DoFactory.ModelConfiguration;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;

namespace Database.DoFactoryV2
{
    public class DoFactoryV2Context : DoFactoryContext
    {
        public DoFactoryV2Context(TenantInfo tenantInfo) : base(tenantInfo)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DoFactory.ModelConfiguration.V2.ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
        }
    }
}
