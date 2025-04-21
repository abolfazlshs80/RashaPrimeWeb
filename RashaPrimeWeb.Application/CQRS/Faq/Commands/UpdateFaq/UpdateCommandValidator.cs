using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.UpdateFaq;

public class UpdateFaqCommandValidator : AbstractValidator<UpdateFaqCommand>
{
    public UpdateFaqCommandValidator()
    {
        RuleFor(u => u.FullName)
               .NotEmpty().WithMessage("this field is required")
               .MinimumLength(5).WithMessage("first name must be  than 5")
               .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}