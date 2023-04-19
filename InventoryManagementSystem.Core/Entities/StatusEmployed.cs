namespace InventoryManagementSystem.Core.entities;

public partial class StatusEmployed
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EmployeeUser> EmployeeUsers { get; set; } = new List<EmployeeUser>();
}
