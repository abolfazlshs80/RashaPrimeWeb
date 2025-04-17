using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Blog.Commands.DeleteBlog;

public record DeleteBlogCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteBlogCommand() : this(0) { }


}