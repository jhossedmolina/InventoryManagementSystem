namespace InventoryManagementSystem.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int IdProductCategory { get; set; }
    }
}
