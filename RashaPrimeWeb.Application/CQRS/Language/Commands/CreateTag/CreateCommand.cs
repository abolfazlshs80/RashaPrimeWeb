using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.CreateLanguage;

public record CreateLanguageCommand : IRequest<ErrorOr<int>>
{


    public string LanguageTitle { get; set; }


    public string Title { get; set; }


}