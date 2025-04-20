using MediatR;

namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetNews;

public record GetNewsQuery(int Id) : IRequest<GetNewsDto>;