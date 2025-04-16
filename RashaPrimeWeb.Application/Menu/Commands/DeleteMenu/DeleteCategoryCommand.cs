using MediatR;

namespace RashaPrimeWeb.Application.Menu.Commands.DeleteCateogry;

public record DeleteMenuCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteMenuCommand() : this(0) { }


}