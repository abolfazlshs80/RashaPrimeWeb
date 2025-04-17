using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;

public record GetAllBlogQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllBlogDto>>;

