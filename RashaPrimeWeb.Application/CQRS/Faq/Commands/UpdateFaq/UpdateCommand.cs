using MediatR;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Faq.Commands.UpdateFaq;

public record UpdateFaqCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public string Text { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
    public string Phone { get; set; }

    public string? ReplayText { get; set; }

    public int? Lang_Id { get; set; }

}