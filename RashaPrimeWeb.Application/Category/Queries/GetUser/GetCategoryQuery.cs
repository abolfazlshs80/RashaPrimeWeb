using MediatR;

namespace RashaPrimeWeb.Application.Category.Queries.GetUser;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryDto>;