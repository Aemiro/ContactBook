using ContactBook.Application.Contacts.Commands;
using FluentValidation;
namespace ContactBook.Application.Contacts.Validators
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Contact Id is required");
        }
    }
}
