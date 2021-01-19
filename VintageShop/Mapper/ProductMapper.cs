using VintageShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VintageShop.Mapper
{
    public class ProductMapper : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(b => b.Description)
                .IsRequired(false)
                .HasColumnType("varchar(350)");

            builder.Property(b => b.Value)
                .IsRequired();

            builder.Property(b => b.ProductDate)
                .IsRequired();

            builder.Property(b => b.CategoryId)
                .IsRequired();

            builder.HasMany(x => x.CategoryProducts)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId); //CategoryId

            builder.ToTable("Products");
        }
    }
}