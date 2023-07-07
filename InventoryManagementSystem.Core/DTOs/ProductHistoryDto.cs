namespace InventoryManagementSystem.Core.DTOs
{
    public class ProductHistoryDto
    {
        public int Id { get; set; }

        public int QuantityProduct { get; set; }

        public int IdProductMovement { get; set; }

        public DateTime UpdateDate { get; set; }

        public int IdProductStock { get; set; }

        public int IdOrderDetail { get; set; }
    }
}
