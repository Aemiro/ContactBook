using ContactBook.Application.Groups.Commands;
using FluentValidation;
namespace ContactBook.Application.Groups.Validations
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Group Id is required");
            RuleFor(command => command.Name).NotEmpty().WithMessage("Group Name is required");
        }
    }
}
