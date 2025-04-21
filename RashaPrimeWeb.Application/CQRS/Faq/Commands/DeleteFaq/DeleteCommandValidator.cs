using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.DeleteFaq;

public class DeleteFaqCommandValidator : AbstractValidator<DeleteFaqCommand>
{
    public DeleteFaqCommandValidator()
    {
        //RuleFor(u => u.Id)
        //       .NotEmpty().WithMessage("this field is required")
        //       .MinimumLength(5).WithMessage("first name must be  than 5")
        //       .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}