using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

public record GetAllTagQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllTagDto>>;

