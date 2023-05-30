using FluentValidation;
using InventoryManagementSystem.Core.DTOs;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class RoleEmployeeValidator : AbstractValidator<RoleEmployeeDto>
    {
        public RoleEmployeeValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull()
                .Length(2, 5);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(3, 10);
        }
    }
}
