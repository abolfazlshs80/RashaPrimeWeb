using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.CreateTag;

public record CreateTagCommand : IRequest<ErrorOr<int>>
{

    public string Name { get; set; }


}