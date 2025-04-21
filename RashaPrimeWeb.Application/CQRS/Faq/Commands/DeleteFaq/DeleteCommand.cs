using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.DeleteFaq;

public record DeleteFaqCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteFaqCommand() : this(0) { }


}