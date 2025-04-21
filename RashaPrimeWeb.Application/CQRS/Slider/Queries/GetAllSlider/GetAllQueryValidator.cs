using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetAllSlider;

public class GetAllSliderQueryValidator : AbstractValidator<GetAllSliderQuery>
{
    public GetAllSliderQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}