using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.CreateFaq;

public class CreateFaqCommandValidator : AbstractValidator<CreateFaqCommand>
{
    public CreateFaqCommandValidator()
    {
        RuleFor(u => u.FullName)
               .NotEmpty().WithMessage("this field is required")
               .MinimumLength(5).WithMessage("first name must be  than 5")
               .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}