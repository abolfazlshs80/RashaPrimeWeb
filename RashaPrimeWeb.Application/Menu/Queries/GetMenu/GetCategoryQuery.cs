using MediatR;

namespace RashaPrimeWeb.Application.Menu.Queries.GetMenu;

public record GetMenuQuery(int Id) : IRequest<GetMenuDto>;