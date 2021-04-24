using FluentValidation;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommand>
    {
        public UpdateToDoCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{Title} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{Title} must not exceed 100 characters.");
        }
    }
}
