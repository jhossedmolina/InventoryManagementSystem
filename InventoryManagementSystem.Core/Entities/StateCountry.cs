﻿namespace InventoryManagementSystem.Core.entities;

public partial class StateCountry
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<MunicipalityCountry> MunicipalityCountries { get; set; } = new List<MunicipalityCountry>();
}
