namespace InventoryManagementSystem.Core.DTOs
{
    public class OrderHistoryDto
    {
        public int Id { get; set; }

        public int IdOrder { get; set; }

        public int IdOrderSatus { get; set; }

        public DateTime UpdateDate { get; set; }

        public int IdOrderDetail { get; set; }
    }
}
