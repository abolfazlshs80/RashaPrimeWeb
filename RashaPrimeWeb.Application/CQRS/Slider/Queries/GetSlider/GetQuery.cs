using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetSlider;

public record GetSliderQuery(int Id) : IRequest<GetSliderDto>;