using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Service.Queries.GetNews;

public record GetServiceQuery(int Id) : IRequest<GetServiceDto>;