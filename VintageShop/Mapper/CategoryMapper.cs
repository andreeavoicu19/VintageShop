using VintageShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VintageShop.Mapper
{
    public class CategoryMapper : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);  

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.HasMany(c => c.Products)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            builder.HasMany(c => c.CategoryProducts)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);
            
            builder.ToTable("Categories");
        }
    }
}