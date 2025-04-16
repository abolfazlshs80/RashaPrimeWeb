using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

public class GetMenuQueryValidator : AbstractValidator<GetMenuQuery>
{
    public GetMenuQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}