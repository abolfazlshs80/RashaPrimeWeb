using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetAllLanguage;

public record GetAllLanguageQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllLanguageDto>>;

