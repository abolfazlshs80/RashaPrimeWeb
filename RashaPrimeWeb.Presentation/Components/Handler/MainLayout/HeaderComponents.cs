using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using Microsoft.Extensions.Localization;


namespace RashaPrimeWeb.WEB.Components.Main
{
    public class HeaderComponents : ViewComponent
    {
      //  private readonly IStringLocalizer _localizer;
        //private readonly IMenuService _menuService;
        //private readonly ITagService _tagService;
        //private readonly ICategoryService _categoryService;
        //private readonly IBlogService _blogService;
        //private readonly INewsService _newsService;
        //private readonly IServiceService _serviceService;
        //private readonly ISettingService _SettingService;
        //private readonly ILanguagesService _languageService;

        //private readonly IMapper _mapper;

        //public HeaderComponents()
        //{
        
        //}
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var Header = new HeaderVM();
            //Header.Setting = await _SettingService.GetCurrentSettingActive();
            //Header.Menu = await _menuService.GetMenuForHeaderActive();
            //Header.Categories = await _categoryService.GetCategoryForHeaderActive();
            //Header.Blogs = await _blogService.GetBlogForHeaderActive();
            //Header.News = await _newsService.GetNewsForHeaderActive();
            //Header.Service = await _serviceService.GetServiceForHeaderActive();
            //Header.Tag = await _tagService.GetTagForHeaderActive();
            //Header.Languages = await _languageService.GetLanguagesLast();
            return View("/Components/Views/MainLayout/Header.cshtml");
        }

    }
}
