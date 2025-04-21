using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;

namespace RashaPrimeWeb.Presentation.Components.Handler.Home
{
    public class NewsSliderHomeComponents(IMediator mediator) : ViewComponent
    {
     
        public async Task<IViewComponentResult> InvokeAsync()
        {

            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllNewsQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Home/news.cshtml", model);
        }

    }
}
