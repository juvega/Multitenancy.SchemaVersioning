using Microsoft.EntityFrameworkCore;
using Database.DoFactory.Models;
using Database.DoFactory.ModelConfiguration;

namespace Database.DoFactory
{
    public class DoFactoryContext : DbContext
    {
        public DoFactoryContext()
        {
        }

        public DoFactoryContext(DbContextOptions<DoFactoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

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
