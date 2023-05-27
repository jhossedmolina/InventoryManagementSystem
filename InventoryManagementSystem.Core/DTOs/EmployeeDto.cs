namespace InventoryManagementSystem.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public int DocNumber { get; set; }

        public int IdDocumentType { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? ContactNumber { get; set; }

        public string? Email { get; set; }
    }
}
