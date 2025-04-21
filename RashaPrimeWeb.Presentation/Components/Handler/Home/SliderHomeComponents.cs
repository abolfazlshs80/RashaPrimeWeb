using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Slider.Queries.GetAllSlider;

namespace RashaPrimeWeb.WEB.Components.Main
{
    public class SliderHomeComponents(IMediator mediator) : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllSliderQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Home/slider.cshtml", model);
        }

    }
}
