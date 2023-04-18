﻿using System;
using System.Collections.Generic;

namespace InventoryManagementSystem.Infraestructure.Migrations;

public partial class Employee
{
    public int Id { get; set; }

    public int DocNumber { get; set; }

    public int IdDocumentType { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int IdRoleEmployee { get; set; }

    public virtual ICollection<EmployeeUser> EmployeeUsers { get; set; } = new List<EmployeeUser>();

    public virtual DocumentType IdDocumentTypeNavigation { get; set; } = null!;

    public virtual RoleEmployee IdRoleEmployeeNavigation { get; set; } = null!;
}
