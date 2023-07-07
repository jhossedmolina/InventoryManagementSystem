using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.ToTable("ProductBrand");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.HasOne(d => d.IdProductCategoryNavigation).WithMany(p => p.ProductBrands)
                .HasForeignKey(d => d.IdProductCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductBrand_ProductCategory");
        }
    }
}
