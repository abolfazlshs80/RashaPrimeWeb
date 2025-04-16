using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

public record GetMenuQuery(int Id) : IRequest<GetMenuDto>;