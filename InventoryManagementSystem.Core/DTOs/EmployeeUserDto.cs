namespace InventoryManagementSystem.Core.DTOs
{
    public class EmployeeUserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int IdEmployee { get; set; }

        public int IdRoleEmployee { get; set; }

        public int IdStatusEmployed { get; set; }
    }
}
