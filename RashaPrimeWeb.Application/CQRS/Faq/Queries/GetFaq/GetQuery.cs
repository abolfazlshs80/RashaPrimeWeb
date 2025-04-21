using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetFaq;

public record GetFaqQuery(int Id) : IRequest<GetFaqDto>;