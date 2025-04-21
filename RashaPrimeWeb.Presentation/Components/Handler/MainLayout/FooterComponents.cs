using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RashaPrimeWeb.WEB.Components.Main
{
    public class FooterComponents : ViewComponent
    {
    

        

       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = new FooterVM();
            //model.Setting = await _SettingService.GetCurrentSettingActive();
            //model.Categories = await _categoryService.GetCategoryActive();
            return View("/Components/Views/MainLayout/Footer.cshtml");
        }

    }
}
