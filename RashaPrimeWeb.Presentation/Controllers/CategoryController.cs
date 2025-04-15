using Microsoft.AspNetCore.Mvc;

using RashaPrimeWeb.Application.Category.Commands.CreateUser;
using RashaPrimeWeb.Application.Category.Queries.GetUser;

namespace MsaterResumeIR.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoryDto>> GetCategory()
    {
        GetCategoryQuery query=new GetCategoryQuery (2);
        var model = await Mediator.Send(query);
      
        
        return Content(model.Name);
    }
    [HttpGet]
    public IActionResult CreateCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand model)
    {
        //var validator = new CreateCategoryCommandValidator();
        //var command = model;
        //var result = validator.Validate(command);

        //if (!result.IsValid)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error.ErrorMessage);
            
        //    }
        //}
        if (!ModelState.IsValid)
        {
            return View();
        }
  //      model.Name = "test" + new Random().Next(1111, 9999);
        var query = await Mediator.Send(model);
        return Content("created");
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
       => await Mediator.Send(command);
}
