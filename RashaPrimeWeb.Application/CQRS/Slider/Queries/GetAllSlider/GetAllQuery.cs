using MediatR;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetAllSlider;

public record GetAllSliderQuery(string? Title, bool GetOldest, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedResult<GetAllSliderDto>>;

