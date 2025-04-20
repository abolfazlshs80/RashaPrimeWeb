using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Service.Queries.GetNews;

public class GetServiceQueryValidator : AbstractValidator<GetServiceQuery>
{
    public GetServiceQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}