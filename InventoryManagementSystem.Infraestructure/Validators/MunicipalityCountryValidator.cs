using FluentValidation;
using InventoryManagementSystem.Core.DTOs;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class MunicipalityCountryValidator : AbstractValidator<MunicipalityCountryDto>
    {
        public MunicipalityCountryValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull()
                .Length(2, 5);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);

            RuleFor(x => x.IdStateCountry)
                .NotEmpty()
                .NotNull();
        }
    }
}
