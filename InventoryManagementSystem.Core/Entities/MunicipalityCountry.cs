namespace InventoryManagementSystem.Core.entities;

public partial class MunicipalityCountry
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int IdStateCountry { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual StateCountry IdStateCountryNavigation { get; set; } = null!;
}
