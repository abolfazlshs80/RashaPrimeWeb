using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.CreateTag;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(u => u.TitleBrowser)
               .NotEmpty().WithMessage("this field is required")
               .MinimumLength(5).WithMessage("first name must be  than 5")
               .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}