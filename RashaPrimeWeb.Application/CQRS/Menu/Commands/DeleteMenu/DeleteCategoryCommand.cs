using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Menu.Commands.DeleteMenu;

public record DeleteMenuCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteMenuCommand() : this(0) { }


}