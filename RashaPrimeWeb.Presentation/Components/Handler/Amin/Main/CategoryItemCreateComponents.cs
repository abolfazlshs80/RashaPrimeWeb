using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

namespace RashaPrimeWeb.Presentation.Components.Handler.Amin.Main
{
    public class CategoryItemCreateComponents(IMediator mediator) : ViewComponent
    {
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllCategoryQuery(null, GetOldest, Page, Take);
            var model = await mediator.Send(query);
            return View("/Components/Views/Admin/Main/CategoryItemCreate.cshtml", model);
        }

    }
}


