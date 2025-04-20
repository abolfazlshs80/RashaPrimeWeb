using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.DeleteTag;

public record DeleteTagCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteTagCommand() : this(0) { }


}