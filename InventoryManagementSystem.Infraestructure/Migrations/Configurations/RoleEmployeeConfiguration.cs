using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    internal class RoleEmployeeConfiguration : IEntityTypeConfiguration<RoleEmployee>
    {
        public void Configure(EntityTypeBuilder<RoleEmployee> builder)
        {
            builder.ToTable("RoleEmployee");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.Code)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("code");
            builder.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
        }
    }
}
