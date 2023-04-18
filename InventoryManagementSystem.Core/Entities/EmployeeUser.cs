namespace InventoryManagementSystem.Core.Entities;
public partial class EmployeeUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdEmployee { get; set; }

    public int IdStatusEmployed { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual StatusEmployed IdStatusEmployedNavigation { get; set; } = null!;
}
