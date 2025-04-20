using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;

public class GetAllNewsQueryValidator : AbstractValidator<GetAllNewsQuery>
{
    public GetAllNewsQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}