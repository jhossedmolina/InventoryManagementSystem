using FluentValidation;
using InventoryManagementSystem.Core.DTOs;


namespace InventoryManagementSystem.Infraestructure.Validators
{
    public class ClientValidator : AbstractValidator<ClientDto>
    {
        public ClientValidator()
        {
            RuleFor(x => x.DocNumber)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.IdDocumentType)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .Length(3, 50);

            RuleFor(x => x.ContactNumber)
                .NotEmpty()
                .NotNull()
                .Length(12, 20);

            RuleFor(x => x.Address)
                .NotEmpty()
                .NotNull()
                .Length(10, 50);
        }
    }
}
