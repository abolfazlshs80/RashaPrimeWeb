using MediatR;

namespace RashaPrimeWeb.Application.CQRS.News.Commands.DeleteNews;

public record DeleteNewsCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteNewsCommand() : this(0) { }


}