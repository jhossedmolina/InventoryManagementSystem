namespace InventoryManagementSystem.Core.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime OrderDeliveryDate { get; set; }

        public string Description { get; set; } = null!;

        public int IdOrderStatus { get; set; }
    }
}
