using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetSlider;

public class GetSliderQueryValidator : AbstractValidator<GetSliderQuery>
{
    public GetSliderQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}