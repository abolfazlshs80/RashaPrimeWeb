using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

public class GetSettingQueryValidator : AbstractValidator<GetSettingQuery>
{
    public GetSettingQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}