using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.DeleteBlog;

public class DeleteBlogCommandValidator : AbstractValidator<DeleteBlogCommand>
{
    public DeleteBlogCommandValidator()
    {
        //RuleFor(u => u.Id)
        //       .NotEmpty().WithMessage("this field is required")
        //       .MinimumLength(5).WithMessage("first name must be  than 5")
        //       .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}