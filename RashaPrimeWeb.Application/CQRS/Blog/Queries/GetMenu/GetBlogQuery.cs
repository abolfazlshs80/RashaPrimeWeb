using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;

public record GetBlogQuery(int Id) : IRequest<GetBlogDto>;