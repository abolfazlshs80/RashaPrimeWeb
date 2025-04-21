using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetFaq;

public class GetFaqQueryValidator : AbstractValidator<GetFaqQuery>
{
    public GetFaqQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}