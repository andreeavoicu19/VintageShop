using VintageShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VintageShop.Mapper
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.HasMany(x => x.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.HasMany(x => x.CategoryProducts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.ToTable("Categories");
        }
    }
}