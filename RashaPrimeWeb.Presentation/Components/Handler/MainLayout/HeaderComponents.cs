using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.Extensions.Localization;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;
using RashaPrimeWeb.Domain.Entities;


namespace RashaPrimeWeb.WEB.Components.Main
{
    public class HeaderComponents(IMediator mediator) : ViewComponent
    {
      
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var queryMenu = new GetAllMenuQuery (null,false,1,10);
            var querySetting = new GetSettingQuery ();
            var Menu = await mediator.Send(queryMenu);
            var Setting = await mediator.Send(querySetting);
            var Header = new HeaderVM();
            Header.Setting = Setting;
            Header.Menu = Menu;
            //Header.Menu = await _menuService.GetMenuForHeaderActive();
            //Header.Categories = await _categoryService.GetCategoryForHeaderActive();
            //Header.Blogs = await _blogService.GetBlogForHeaderActive();
            //Header.News = await _newsService.GetNewsForHeaderActive();
            //Header.Service = await _serviceService.GetServiceForHeaderActive();
            //Header.Tag = await _tagService.GetTagForHeaderActive();
            //Header.Languages = await _languageService.GetLanguagesLast();
            return View("/Components/Views/MainLayout/Header.cshtml",Header);
        }

    }
}
