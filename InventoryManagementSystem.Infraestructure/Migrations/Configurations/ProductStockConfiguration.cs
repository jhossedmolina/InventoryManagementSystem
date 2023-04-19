using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_MaterialStock");

            builder.ToTable("ProductStock");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdProduct).HasColumnName("idProduct");
            builder.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");

            builder.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductStock_Product");
        }
    }
}
