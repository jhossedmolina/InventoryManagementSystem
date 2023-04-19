using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client> 
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            builder.Property(e => e.DocNumber).HasColumnName("docNumber");
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            builder.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");
            builder.Property(e => e.IdMunicipalityCountry).HasColumnName("idMunicipalityCountry");
            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");

            builder.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_DocumentType");

            builder.HasOne(d => d.IdMunicipalityCountryNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdMunicipalityCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_MunicipalityCountry");
        }
    }
}
