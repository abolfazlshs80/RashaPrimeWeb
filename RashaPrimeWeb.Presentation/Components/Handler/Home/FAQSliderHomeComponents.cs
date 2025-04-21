using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Faq.Queries.GetAllFaq;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;

namespace RashaPrimeWeb.Presentation.Components.Handler.Home
{
    public class FAQSliderHomeComponents(IMediator mediator) : ViewComponent
    {
   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllFaqQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Home/FAQSlider.cshtml", model);
        }

    }
}
