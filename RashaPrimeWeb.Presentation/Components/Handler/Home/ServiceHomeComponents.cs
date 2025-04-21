using MediatR;
using Microsoft.AspNetCore.Mvc;
using nameSpace.MVC.Contracts;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;

namespace RashaPrimeWeb.WEB.Components.Home
{
    public class ServiceHomeComponents(IMediator mediator) : ViewComponent
    {
 

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllServiceQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Home/ServiceHome.cshtml",model);
        }

    }
}
