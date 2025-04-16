using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.Category.Queries.GetAllCategory;

public record GetAllCategoryQuery(string? Title, bool GetOldest, int PageNumber=1, int PageSize=10) : IRequest<PaginatedResult<GetAllCategoryDto>>;

