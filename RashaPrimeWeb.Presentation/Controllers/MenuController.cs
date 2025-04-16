using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Presentation.Controllers;
using RashaPrimeWeb.Application.CQRS.Menu.Commands.CreateMenu;
using RashaPrimeWeb.Application.CQRS.Menu.Commands.DeleteMenu;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

namespace RashaPrimeWeb.Presentation.Controllers;

public class MenuController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetMenuDto>> GetMenu()
    {
        var query=new GetAllMenuQuery (null, false,1,8);
      //  var query=new GetMenuQuery (2);
        var model = await Mediator.Send(query);
      
        
        return Content("");
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuCommand model)
    {
        model.Id = 0;
        model.ControllerName = model.Title;
        model.Href = model.Title;
        model.Icons = model.Title;
        model.Order = 1;
        model.StatusInAdminMenu = false;
        model.StatusInFooter = false;
        model.StatusInMainMenu = false;
        model.StatusInUserFooterMenu = false;
        model.StatusInUserMenu = false;
        model.RoleName = "Admin";
        //if (!ModelState.IsValid)
        //{
        //    return View();
        //}
        //      model.Name = "test" + new Random().Next(1111, 9999);
       var query = await Mediator.Send(model);
      //  var query = await Mediator.Send(new DeleteMenuCommand{Id = 1});
        if (query.IsError)
        {
            return Content("dont created");
        }
        return Content("created");
    }

}
