using ContactBook.Application.Groups.Commands;
using FluentValidation;
namespace ContactBook.Application.Groups.Validations
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().WithMessage("Group name is required");
        }
    }
}
