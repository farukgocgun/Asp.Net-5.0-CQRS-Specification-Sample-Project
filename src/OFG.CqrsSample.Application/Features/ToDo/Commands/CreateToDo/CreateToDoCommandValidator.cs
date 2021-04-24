using FluentValidation;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{Title} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{Title} must not exceed 100 characters.");

        }
    }
}
