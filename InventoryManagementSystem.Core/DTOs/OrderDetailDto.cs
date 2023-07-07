namespace InventoryManagementSystem.Core.DTOs
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public DateTime UpdateDate { get; set; }

        public int IdOrder { get; set; }

        public string Observations { get; set; } = null!;

        public int IdProductHistory { get; set; }

        public int QuantityProduct { get; set; }
    }
}
