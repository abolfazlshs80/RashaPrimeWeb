using FluentValidation;

namespace RashaPrimeWeb.Application.Menu.Queries.GetAllCategory;

public class GetAllCategoryQueryValidator : AbstractValidator<GetAllCategoryQuery>
{
    public GetAllCategoryQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}