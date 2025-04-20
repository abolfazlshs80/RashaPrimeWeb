using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetTag;

public record GetTagQuery(int Id) : IRequest<GetTagDto>;