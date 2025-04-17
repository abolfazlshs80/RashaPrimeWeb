using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;

public class GetBlogQueryValidator : AbstractValidator<GetBlogQuery>
{
    public GetBlogQueryValidator()
    {
        RuleFor(u => u.Id)
            .NotEmpty()
            .WithMessage("this field is Required");
    }
}