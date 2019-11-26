using Database.DoFactory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.DoFactory.ModelConfiguration
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Models.Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasIndex(e => e.CustomerId)
                    .HasName("IndexOrderCustomerId");

            builder.HasIndex(e => e.OrderDate)
                    .HasName("IndexOrderOrderDate");

            builder.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.OrderNumber).HasMaxLength(10);

            builder.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

            builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
        }
    }
}
