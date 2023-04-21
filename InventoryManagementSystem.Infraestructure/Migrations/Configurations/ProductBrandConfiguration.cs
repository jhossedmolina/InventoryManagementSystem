using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_ProductBrand");

            builder.ToTable("ProductBrand");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
