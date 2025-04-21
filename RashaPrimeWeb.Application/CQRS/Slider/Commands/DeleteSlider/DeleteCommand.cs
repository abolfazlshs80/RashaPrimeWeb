using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.DeleteSlider;

public record DeleteSliderCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteSliderCommand() : this(0) { }


}