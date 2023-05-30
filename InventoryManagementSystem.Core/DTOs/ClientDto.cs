namespace InventoryManagementSystem.Core.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }

        public int DocNumber { get; set; }

        public int IdDocumentType { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string ContactNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int IdMunicipalityCountry { get; set; }
    }
}
