using Database.DoFactory.ModelConfiguration;
using Database.DoFactory.ModelConfiguration.v3;
using Database.DoFactory.Models;
using Database.DoFactoryV2;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;

namespace Database.DoFactoryV3
{
    public class DoFactoryV3Context : DoFactoryV2Context
    {
        public DoFactoryV3Context(TenantInfo tenantInfo) : base(tenantInfo)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DoFactory.ModelConfiguration.V2.ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfiguration());
        }
    }
}
