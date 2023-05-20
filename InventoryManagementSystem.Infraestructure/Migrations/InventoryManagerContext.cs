using InventoryManagementSystem.Core.entities;
using InventoryManagementSystem.Infraestructure.Migrations.Configurations;
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

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductBrandConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeUserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MunicipalityCountryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDetailConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderHistoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderStatusConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryConfiguraation).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductHistoryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMovementConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductStockConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleEmployeeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StateCountryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StatusEmployed).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
