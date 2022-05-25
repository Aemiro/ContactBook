using ContactBook.Application.Groups.Commands;
using FluentValidation;
namespace ContactBook.Application.Groups.Validations
{
    public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Group Id is required");
        }
    }
}
