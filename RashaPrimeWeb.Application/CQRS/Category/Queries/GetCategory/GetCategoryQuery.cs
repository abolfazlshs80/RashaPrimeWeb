using MediatR;


namespace RashaPrimeWeb.Application.CQRS.Category.Queries.GetCategory;

public record GetCategoryQuery(int Id) : IRequest<GetCategoryDto>;