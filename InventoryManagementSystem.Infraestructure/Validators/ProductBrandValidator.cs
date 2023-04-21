using FluentValidation;
using InventoryManagementSystem.Core.entities;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class ProductBrandValidator : AbstractValidator<ProductBrand>
    {
        public ProductBrandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(50);
        }
    }
}
