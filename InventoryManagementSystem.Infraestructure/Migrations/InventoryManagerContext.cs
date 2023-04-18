using InventoryManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Infraestructure.Migrations;

public partial class InventoryManagerContext : DbContext
{
    public InventoryManagerContext()
    {
    }

    public InventoryManagerContext(DbContextOptions<InventoryManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandProduct> BrandProducts { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeUser> EmployeeUsers { get; set; }

    public virtual DbSet<MunicipalityCountry> MunicipalityCountries { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductHistory> ProductHistories { get; set; }

    public virtual DbSet<ProductMovement> ProductMovements { get; set; }

    public virtual DbSet<ProductStock> ProductStocks { get; set; }

    public virtual DbSet<RoleEmployee> RoleEmployees { get; set; }

    public virtual DbSet<StateCountry> StateCountries { get; set; }

    public virtual DbSet<StatusEmployed> StatusEmployeds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductBrand");

            entity.ToTable("BrandProduct");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.DocNumber).HasColumnName("docNumber");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");
            entity.Property(e => e.IdMunicipalityCountry).HasColumnName("idMunicipalityCountry");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");

            entity.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_DocumentType");

            entity.HasOne(d => d.IdMunicipalityCountryNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdMunicipalityCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_MunicipalityCountry");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.ToTable("DocumentType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocNumber).HasColumnName("docNumber");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IdDocumentType).HasColumnName("idDocumentType");
            entity.Property(e => e.IdRoleEmployee).HasColumnName("idRoleEmployee");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");

            entity.HasOne(d => d.IdDocumentTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_DocumentType");

            entity.HasOne(d => d.IdRoleEmployeeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdRoleEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_RoleEmployee");
        });

        modelBuilder.Entity<EmployeeUser>(entity =>
        {
            entity.ToTable("EmployeeUser");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdStatusEmployed).HasColumnName("idStatusEmployed");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.EmployeeUsers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeUser_Employee");

            entity.HasOne(d => d.IdStatusEmployedNavigation).WithMany(p => p.EmployeeUsers)
                .HasForeignKey(d => d.IdStatusEmployed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeUser_StatusEmployed");
        });

        modelBuilder.Entity<MunicipalityCountry>(entity =>
        {
            entity.ToTable("MunicipalityCountry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdStateCountry).HasColumnName("idStateCountry");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdStateCountryNavigation).WithMany(p => p.MunicipalityCountries)
                .HasForeignKey(d => d.IdStateCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MunicipalityCountry_StateCountry");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdOrderStatus).HasColumnName("idOrderStatus");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderDeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDeliveryDate");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Client");

            entity.HasOne(d => d.IdOrderStatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOrderStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_OrderStatus");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrderDetails");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdProductHistory).HasColumnName("idProductHistory");
            entity.Property(e => e.Observations)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Order");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.ToTable("OrderHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrder).HasColumnName("idOrder");
            entity.Property(e => e.IdOrderDetail).HasColumnName("idOrderDetail");
            entity.Property(e => e.IdOrderSatus).HasColumnName("idOrderSatus");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_Order");

            entity.HasOne(d => d.IdOrderDetailNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrderDetail)
                .HasConstraintName("FK_OrderHistory_OrderDetail");

            entity.HasOne(d => d.IdOrderSatusNavigation).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.IdOrderSatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderHistory_OrderHistory");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdProductCategory).HasColumnName("idProductCategory");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdProductCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProductCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.IdBrandProduct).HasColumnName("idBrandProduct");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdBrandProductNavigation).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.IdBrandProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategory_BrandProduct");
        });

        modelBuilder.Entity<ProductHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventoryMaterial");

            entity.ToTable("ProductHistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOrderDetail).HasColumnName("idOrderDetail");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdProductMovement).HasColumnName("idProductMovement");
            entity.Property(e => e.IdProductStock).HasColumnName("idProductStock");
            entity.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.IdOrderDetailNavigation).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.IdOrderDetail)
                .HasConstraintName("FK_InventoryMaterial_OrderDetails");

            entity.HasOne(d => d.IdProductMovementNavigation).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.IdProductMovement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductHistory_ProductMovement");

            entity.HasOne(d => d.IdProductStockNavigation).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.IdProductStock)
                .HasConstraintName("FK_InventoryMaterial_MaterialStock");
        });

        modelBuilder.Entity<ProductMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MaterialMovements");

            entity.ToTable("ProductMovement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MaterialStock");

            entity.ToTable("ProductStock");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.QuantityProduct).HasColumnName("quantityProduct");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductStock_Product");
        });

        modelBuilder.Entity<RoleEmployee>(entity =>
        {
            entity.ToTable("RoleEmployee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StateCountry>(entity =>
        {
            entity.ToTable("StateCountry");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StatusEmployed>(entity =>
        {
            entity.ToTable("StatusEmployed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
