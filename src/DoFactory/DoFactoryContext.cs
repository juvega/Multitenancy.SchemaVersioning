using Microsoft.EntityFrameworkCore;
using Database.DoFactory.Models;
using Database.DoFactory.ModelConfiguration;
using Finbuckle.MultiTenant;

namespace Database.DoFactory
{
    public class DoFactoryContext : MultiTenantDbContext
    {
        public DoFactoryContext(TenantInfo tenantInfo) : base(tenantInfo) { }
        public DoFactoryContext(TenantInfo tenantInfo, DbContextOptions<DoFactoryContext> options) : base(tenantInfo, options) { }


        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
        }
    }
}
