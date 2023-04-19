using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class ProductMovementConfiguration : IEntityTypeConfiguration<ProductMovement>
    {
        public void Configure(EntityTypeBuilder<ProductMovement> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_MaterialMovements");

            builder.ToTable("ProductMovement");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
