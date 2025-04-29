using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.Models.ViewModel.Admin.HtmlHelper;


namespace Kashi_Seramic.MVC.Components.Admin.Category
{
    public class CategoryItemCreateSelectedComponents(IMediator mediator) : ViewComponent
    {
    
        public async Task<IViewComponentResult> InvokeAsync(List<int>  cates)
        {

            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var query = new GetAllCategoryQuery(null, GetOldest, Page, Take);
            var res_query = await mediator.Send(query);
            var model = new ListDropDownCategory();
            model.Category = res_query.Items;
            model.CategoryActive = cates;
            return View("/Components/Views/Admin/Main/CategoryItemCreateSelected.cshtml", model);
        }

    }
}


