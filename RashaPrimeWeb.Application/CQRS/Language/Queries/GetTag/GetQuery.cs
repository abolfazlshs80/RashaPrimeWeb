using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetLanguage;

public record GetLanguageQuery(int Id) : IRequest<GetLanguageDto>;