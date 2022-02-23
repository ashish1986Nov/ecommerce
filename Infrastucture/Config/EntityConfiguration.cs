using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace Infrastucture.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Price).HasColumnType("Decimal(18,2)");
            builder.HasOne(p => p.ProductBrand).WithMany();

        }

        public void Configure(EntityTypeBuilder<ProductType> builder)
        {

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            
        }

        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);


        }
    }
}
