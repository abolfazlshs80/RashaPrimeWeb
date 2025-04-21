using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;
using RashaPrimeWeb.Application.Models.ViewModel.MainLayout;

namespace RashaPrimeWeb.Presentation.Components.Handler.MainLayout
{
    public class FooterComponents(IMediator mediator) : ViewComponent
    {
    

        

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;

            var model = new FooterVM();

            var querySetting = new GetSettingQuery();
            var queryCategory = new GetAllCategoryQuery(null, GetOldest, Page, Take);
            var queryMenu = new GetAllMenuQuery(null, GetOldest, Page, Take);
            var Category = await mediator.Send(queryCategory);
            var Setting = await mediator.Send(querySetting);
            var Menu = await mediator.Send(queryMenu);
            model.Categories = Category;
            model.Menu = Menu;
            model.Setting = Setting;
            return View("/Components/Views/MainLayout/Footer.cshtml",model);
        }

    }
}
