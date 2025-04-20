using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.Extensions.Localization;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;
using RashaPrimeWeb.Domain.Entities;


namespace RashaPrimeWeb.WEB.Components.Main
{
    public class HeaderComponents(IMediator mediator) : ViewComponent
    {
      
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Header = new HeaderVM();
            var querySetting = new GetSettingQuery();
            var queryBlog = new GetAllBlogQuery (null,false,1,10);
            var querySerive = new GetAllServiceQuery (null,false,1,10);
            var queryNews = new GetAllNewsQuery (null,false,1,10);
            var queryMenu = new GetAllMenuQuery (null,false,1,10);
            var queryCategory = new GetAllCategoryQuery (null,false,1,10);
           

            var Menu = await mediator.Send(queryMenu);
            var Setting = await mediator.Send(querySetting);
            var Category = await mediator.Send(queryCategory);
            var Blog = await mediator.Send(queryBlog);
            var News = await mediator.Send(queryNews);
            var Service = await mediator.Send(querySerive);
            
            Header.Setting = Setting;
            Header.Menu = Menu;
            Header.Service = Service;

            Header.Categories = Category;
            Header.Blogs = Blog;
            Header.News =News;
      
            //Header.Tag = await _tagService.GetTagForHeaderActive();
            //Header.Languages = await _languageService.GetLanguagesLast();
            return View("/Components/Views/MainLayout/Header.cshtml",Header);
        }

    }
}
