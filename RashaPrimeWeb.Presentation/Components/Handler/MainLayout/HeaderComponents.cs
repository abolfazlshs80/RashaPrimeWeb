using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Language.Queries.GetAllLanguage;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;
using RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

namespace RashaPrimeWeb.Presentation.Components.Handler.MainLayout
{
    public class HeaderComponents(IMediator mediator) : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;

            var Header = new HeaderVM();
            var querySetting = new GetSettingQuery();
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            var querySerive = new GetAllServiceQuery(null, GetOldest, Page, Take);
            var queryNews = new GetAllNewsQuery(null, GetOldest, Page, Take);
            var queryMenu = new GetAllMenuQuery(null, GetOldest, Page, Take);
            var queryCategory = new GetAllCategoryQuery(null, GetOldest, Page, Take);
            var queryTag = new GetAllTagQuery(null, GetOldest, Page, Take);
            var queryLanguage = new GetAllLanguageQuery(null, GetOldest, Page, Take);


            var Menu = await mediator.Send(queryMenu);
            var Setting = await mediator.Send(querySetting);
            var Category = await mediator.Send(queryCategory);
            var Blog = await mediator.Send(queryBlog);
            var News = await mediator.Send(queryNews);
            var Service = await mediator.Send(querySerive);
            var Tag = await mediator.Send(queryTag);
            var Language = await mediator.Send(queryLanguage);

            Header.Setting = Setting;
            Header.Menu = Menu;
            Header.Service = Service;
            Header.Categories = Category;
            Header.Blogs = Blog;
            Header.News = News;
            Header.Tag = Tag;
            Header.Languages = Language;

            //Header.Tag = await _tagService.GetTagForHeaderActive();
            //Header.Languages = await _languageService.GetLanguagesLast();
            return View("/Components/Views/MainLayout/Header.cshtml", Header);
        }

    }
}
