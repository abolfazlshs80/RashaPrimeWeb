using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Service.Commands.DeleteNews;

public record DeleteServiceCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteServiceCommand() : this(0) { }


}