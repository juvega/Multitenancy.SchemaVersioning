using System;
using Database.DoFactory.ModelConfiguration;
using Database.DoFactory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.DoFactoryV2
{
    public class DoFactoryNewContext : DbContext
    {
        public DoFactoryNewContext(DbContextOptions<DoFactoryNewContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }


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
