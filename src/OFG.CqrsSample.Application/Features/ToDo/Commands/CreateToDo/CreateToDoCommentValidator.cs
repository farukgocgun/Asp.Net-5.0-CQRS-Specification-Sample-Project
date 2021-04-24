using FluentValidation;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommentValidator : AbstractValidator<CreateToDoCommentCommand>
    {
        public CreateToDoCommentValidator()
        {
            RuleFor(p => p.Comment)
                .NotEmpty().NotNull().WithMessage("{Comment} is required.");

        }
    }
}
