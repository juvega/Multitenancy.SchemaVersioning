using Database.DoFactory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.DoFactory.ModelConfiguration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureBaseFields();

            builder.ConfigureVersion10();
        }
    }
}
