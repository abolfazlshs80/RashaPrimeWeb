using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.CreateSlider;

public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(u => u.Title)
               .NotEmpty().WithMessage("this field is required")
               .MinimumLength(5).WithMessage("first name must be  than 5")
               .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}