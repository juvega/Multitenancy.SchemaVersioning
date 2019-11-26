using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Database.DoFactory.ModelConfiguration
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Models.Customer>
    {
        public void Configure(EntityTypeBuilder<Models.Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasIndex(e => new { e.LastName, e.FirstName })
                .HasName("IndexCustomerName");

            builder.Property(e => e.City).HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(40);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.Phone).HasMaxLength(20);
        }
    }
}
