using ContactBook.Application.Contacts.Commands;
using FluentValidation;
namespace ContactBook.Application.Contacts.Validators
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("Contact Name is required");
            RuleFor(command => command.Phone).NotEmpty().WithMessage("Contact Phone is required");
        }
    }
}
