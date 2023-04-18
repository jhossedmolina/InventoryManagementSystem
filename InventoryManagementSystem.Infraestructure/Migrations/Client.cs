using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Infraestructure.Migrations;

public partial class Client
{
    public int Id { get; set; }

    public int DocNumber { get; set; }

    public int IdDocumentType { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int IdMunicipalityCountry { get; set; }

    public virtual DocumentType IdDocumentTypeNavigation { get; set; } = null!;

    public virtual MunicipalityCountry IdMunicipalityCountryNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
