using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

public class GetAllTagQueryValidator : AbstractValidator<GetAllTagQuery>
{
    public GetAllTagQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}