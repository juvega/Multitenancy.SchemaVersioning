using Database.DoFactory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.DoFactory.ModelConfiguration
{
    public class OrderItemTypeConfiguration : IEntityTypeConfiguration<Models.OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasIndex(e => e.OrderId)
                .HasName("IndexOrderItemOrderId");

            builder.HasIndex(e => e.ProductId)
                .HasName("IndexOrderItemProductId");

            builder.Property(e => e.Quantity).HasDefaultValueSql("((1))");

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

            builder.HasOne(d => d.Order)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

            builder.HasOne(d => d.Product)
                .WithMany(p => p.OrderItem)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");

        }
    }
}
