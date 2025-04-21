using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

namespace RashaPrimeWeb.Presentation.Components.Handler.Home
{
    public class ContactUsInformation(IMediator mediator) : ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var querySetting = new GetSettingQuery();
            var Setting = await mediator.Send(querySetting);
            return View("/Components/Views/Home/ContactUsInfo.cshtml", Setting);
        }

    }
}
