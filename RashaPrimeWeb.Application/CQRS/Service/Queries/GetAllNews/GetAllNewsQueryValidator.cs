using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;

public class GetAllServiceQueryValidator : AbstractValidator<GetAllServiceQuery>
{
    public GetAllServiceQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}