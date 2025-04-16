using MediatR;
using RashaPrimeWeb.Application.Common.Models;


namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;

public record GetAllMenuQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllMenuDto>>;

