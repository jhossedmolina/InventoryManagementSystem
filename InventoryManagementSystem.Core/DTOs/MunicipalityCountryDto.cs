namespace InventoryManagementSystem.Core.DTOs
{
    public class MunicipalityCountryDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int IdStateCountry { get; set; }
    }
}
