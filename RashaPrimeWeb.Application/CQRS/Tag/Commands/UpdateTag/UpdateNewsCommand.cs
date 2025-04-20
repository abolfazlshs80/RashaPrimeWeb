using MediatR;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Tag.Commands.UpdateTag;

public record UpdateTagCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public string Name { get; set; }

}