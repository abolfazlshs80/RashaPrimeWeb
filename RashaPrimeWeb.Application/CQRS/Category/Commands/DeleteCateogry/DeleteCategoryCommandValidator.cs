using FluentValidation;

namespace RashaPrimeWeb.Application.CQRS.Category.Commands.DeleteCateogry;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        //RuleFor(u => u.Id)
        //       .NotEmpty().WithMessage("this field is required")
        //       .MinimumLength(5).WithMessage("first name must be  than 5")
        //       .MaximumLength(50).WithMessage("first name must be less than 50");
    }
}