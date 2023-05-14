using FluentValidation;
using InventoryManagementSystem.Core.DTOs;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class ProductBrandValidator : AbstractValidator<ProductBrandDto>
    {
        public ProductBrandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(4, 50);
        }
    }
}
