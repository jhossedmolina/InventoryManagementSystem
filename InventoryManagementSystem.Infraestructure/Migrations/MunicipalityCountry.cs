using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Infraestructure.Migrations;

public partial class MunicipalityCountry
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdStateCountry { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual StateCountry IdStateCountryNavigation { get; set; } = null!;
}
