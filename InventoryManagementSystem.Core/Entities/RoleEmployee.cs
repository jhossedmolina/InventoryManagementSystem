namespace InventoryManagementSystem.Core.entities;

public partial class RoleEmployee
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<EmployeeUser> EmployeeUsers { get; set; } = new List<EmployeeUser>();
}
