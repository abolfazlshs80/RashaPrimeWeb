using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetAllFaq;

public record GetAllFaqQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllFaqDto>>;

