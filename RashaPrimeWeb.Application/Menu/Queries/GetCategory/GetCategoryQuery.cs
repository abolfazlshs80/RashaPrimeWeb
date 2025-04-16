using MediatR;

namespace RashaPrimeWeb.Application.Menu.Queries.GetCategory;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryDto>;