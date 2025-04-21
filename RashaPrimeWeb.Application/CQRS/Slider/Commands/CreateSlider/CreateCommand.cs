using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Slider.Commands.CreateSlider;

public record CreateSliderCommand : IRequest<ErrorOr<int>>
{

    public string Title { get; set; }

    public string Text { get; set; }
    public string PathImage { get; set; }
    public int Order { get; set; }

    public int? Lang_Id { get; set; }


}