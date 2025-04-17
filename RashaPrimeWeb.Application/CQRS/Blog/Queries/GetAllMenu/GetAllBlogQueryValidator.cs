using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;

public class GetAllBlogQueryValidator : AbstractValidator<GetAllBlogQuery>
{
    public GetAllBlogQueryValidator()
    {
        //RuleFor(u => u.Id)
        //    .NotEmpty()
        //    .WithMessage("this field is Required");
    }
}