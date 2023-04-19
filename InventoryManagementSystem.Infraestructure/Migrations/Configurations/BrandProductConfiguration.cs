using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class BrandProductConfiguration : IEntityTypeConfiguration<BrandProduct>
    {
        public void Configure(EntityTypeBuilder<BrandProduct> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_ProductBrand");

            builder.ToTable("BrandProduct");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
