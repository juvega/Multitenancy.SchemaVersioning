using System;
using Database.DoFactory.ModelConfiguration;
using Database.DoFactory.Models;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.DoFactoryV2
{
    public class DoFactoryNewContext : MultiTenantDbContext
    {

        public DoFactoryNewContext(TenantInfo tenantInfo) : base(tenantInfo) { }
        public DoFactoryNewContext(TenantInfo tenantInfo, DbContextOptions<DoFactoryNewContext> options) : base(tenantInfo, options) { }


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
            modelBuilder.ApplyConfiguration(new DoFactory.ModelConfiguration.V2.ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
        }
    }
}
