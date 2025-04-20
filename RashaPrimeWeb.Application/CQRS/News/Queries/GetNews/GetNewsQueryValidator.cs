using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetNews;

public class GetNewsQueryValidator : AbstractValidator<GetNewsQuery>
{
    public GetNewsQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}