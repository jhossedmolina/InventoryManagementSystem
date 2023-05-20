using FluentValidation;
using InventoryManagementSystem.Core.DTOs;

namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class DocumentTypeValidator : AbstractValidator<DocumentTypeDto>
    {
        public DocumentTypeValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull()
                .Length(1, 4);

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(7, 20);
        }
    }
}
