using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.UpdateTag;

public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(u => u.Name)
               .NotEmpty().WithMessage("this field is required")
               .MinimumLength(5).WithMessage("first name must be  than 5")
               .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}