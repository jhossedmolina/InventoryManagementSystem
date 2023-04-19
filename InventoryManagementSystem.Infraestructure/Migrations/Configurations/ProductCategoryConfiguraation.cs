using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    internal class ProductCategoryConfiguraation : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            builder.Property(e => e.IdBrandProduct).HasColumnName("idBrandProduct");
            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");

            builder.HasOne(d => d.IdBrandProductNavigation).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.IdBrandProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategory_BrandProduct");
        }
    }
}
