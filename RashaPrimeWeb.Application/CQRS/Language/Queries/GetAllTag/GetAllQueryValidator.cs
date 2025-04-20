using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetAllLanguage;

public class GetAllLanguageQueryValidator : AbstractValidator<GetAllLanguageQuery>
{
    public GetAllLanguageQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}