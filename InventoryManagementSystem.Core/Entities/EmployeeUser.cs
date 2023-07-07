namespace InventoryManagementSystem.Core.entities;

public partial class EmployeeUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdEmployee { get; set; }

    public int IdRoleEmployee { get; set; }

    public int IdStatusEmployed { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual RoleEmployee IdRoleEmployeeNavigation { get; set; } = null!;

    public virtual StatusEmployed IdStatusEmployedNavigation { get; set; } = null!;
}
