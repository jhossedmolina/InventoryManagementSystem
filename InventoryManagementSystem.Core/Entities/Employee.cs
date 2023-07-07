namespace InventoryManagementSystem.Core.entities;

public partial class Employee
{
    public int Id { get; set; }

    public int DocNumber { get; set; }

    public int IdDocumentType { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<EmployeeUser> EmployeeUsers { get; set; } = new List<EmployeeUser>();

    public virtual DocumentType IdDocumentTypeNavigation { get; set; } = null!;
}
