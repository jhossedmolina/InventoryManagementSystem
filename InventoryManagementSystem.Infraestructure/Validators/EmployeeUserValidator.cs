using FluentValidation;
using InventoryManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class EmployeeUserValidator : AbstractValidator<EmployeeUserDto>
    {
        public EmployeeUserValidator()
        {
            RuleFor(x => x.Username);
            RuleFor(x => x.Password);


        }
    }
}
