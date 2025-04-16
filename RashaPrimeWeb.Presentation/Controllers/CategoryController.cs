using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Presentation.Controllers;

using RashaPrimeWeb.Application.CQRS.Category.Commands.CreateCateogry;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetCategory;

namespace RashaPrimeWeb.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoryDto>> GetCategory()
    {
        var query=new GetAllCategoryQuery ("11111", false,2,2);
        var model = await Mediator.Send(query);
      
        
        return Content("completed");
    }
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand model)
    {
 
        if (!ModelState.IsValid)
        {
            return View();
        }
  //      model.Name = "test" + new Random().Next(1111, 9999);
        var query = await Mediator.Send(model);
        if (query.IsError)
        {
            return Content("dont created");
        }
        return Content("created");
    }

}
