using MediatR;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.UpdateSlider;

public record UpdateSliderCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public string Title { get; set; }

    public string Text { get; set; }
    public string PathImage { get; set; }
    public int Order { get; set; }

    public int? Lang_Id { get; set; }

}