using MediatR;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Language.Commands.UpdateLanguage;

public record UpdateLanguageCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public int? Lang_Id { get; set; }

    public string LanguageTitle { get; set; }


    public string Title { get; set; }

}