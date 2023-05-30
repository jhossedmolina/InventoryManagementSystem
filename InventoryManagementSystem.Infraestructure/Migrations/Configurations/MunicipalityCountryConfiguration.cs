using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class MunicipalityCountryConfiguration : IEntityTypeConfiguration<MunicipalityCountry>
    {
        public void Configure(EntityTypeBuilder<MunicipalityCountry> builder)
        {
            builder.ToTable("MunicipalityCountry");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdStateCountry).HasColumnName("idStateCountry");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            builder.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");

            builder.HasOne(d => d.IdStateCountryNavigation).WithMany(p => p.MunicipalityCountries)
                .HasForeignKey(d => d.IdStateCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MunicipalityCountry_StateCountry");
        }
    }
}
