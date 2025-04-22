using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

namespace Kashi_Seramic.MVC.Components.Admin.Tag
{
    public class TagItemCreateComponents(IMediator mediator) : ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllTagQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Admin/Main/TageItemCreate.cshtml", model);
        }

    }
}


