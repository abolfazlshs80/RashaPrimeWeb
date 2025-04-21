using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetAllFaq;

public class GetAllFaqQueryValidator : AbstractValidator<GetAllFaqQuery>
{
    public GetAllFaqQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}