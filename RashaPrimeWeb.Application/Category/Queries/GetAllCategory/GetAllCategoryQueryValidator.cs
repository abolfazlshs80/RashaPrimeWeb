using FluentValidation;

namespace RashaPrimeWeb.Application.Category.Queries.GetAllCategory;

public class GetAllCategoryQueryValidator : AbstractValidator<GetAllCategoryQuery>
{
    public GetAllCategoryQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}