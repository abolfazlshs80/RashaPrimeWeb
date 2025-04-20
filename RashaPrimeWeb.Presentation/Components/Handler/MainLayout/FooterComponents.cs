using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RashaPrimeWeb.WEB.Components.Main
{
    public class FooterComponents : ViewComponent
    {
        //private readonly IMenuService _menuService;
        //private readonly ISettingService _SettingService;
        //private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        //public FooterComponents(IMenuService menuService,
        //    IMapper mapper,
        //    ISettingService settingService,ICategoryService categoryService)
        //{
        //    _menuService = menuService;
        //    _categoryService = categoryService;
        //    _mapper = mapper;
        //    _SettingService = settingService;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = new FooterVM();
            //model.Setting = await _SettingService.GetCurrentSettingActive();
            //model.Categories = await _categoryService.GetCategoryActive();
            return View("/Components/Views/MainLayout/Footer.cshtml");
        }

    }
}
