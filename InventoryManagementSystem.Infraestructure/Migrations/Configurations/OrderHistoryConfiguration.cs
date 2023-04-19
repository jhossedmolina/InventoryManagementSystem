using InventoryManagementSystem.Core.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagementSystem.Infraestructure.Migrations.Configurations
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("OrderHistory");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdOrder).HasColumnName("idOrder");
            builder.Property(e => e.IdOrderDetail).HasColumnName("idOrderDetail");
            builder.Property(e => e.IdOrderSatus).HasColumnName("idOrderSatus");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            builder.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_Order");

            builder.HasOne(d => d.IdOrderDetailNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrderDetail)
                .HasConstraintName("FK_OrderHistory_OrderDetail");

            builder.HasOne(d => d.IdOrderSatusNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrderSatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_OrderHistory");
        }
    }
}
