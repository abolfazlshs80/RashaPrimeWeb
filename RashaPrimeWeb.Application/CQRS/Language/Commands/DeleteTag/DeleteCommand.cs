using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.DeleteLanguage;

public record DeleteLanguageCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteLanguageCommand() : this(0) { }


}