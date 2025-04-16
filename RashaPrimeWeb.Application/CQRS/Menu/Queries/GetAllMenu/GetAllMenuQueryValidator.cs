using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;

public class GetAllMenuQueryValidator : AbstractValidator<GetAllMenuQuery>
{
    public GetAllMenuQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}