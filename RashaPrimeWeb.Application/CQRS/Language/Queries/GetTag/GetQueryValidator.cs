using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetLanguage;

public class GetLanguageQueryValidator : AbstractValidator<GetLanguageQuery>
{
    public GetLanguageQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}