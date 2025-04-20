using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetTag;

public class GetTagQueryValidator : AbstractValidator<GetTagQuery>
{
    public GetTagQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}