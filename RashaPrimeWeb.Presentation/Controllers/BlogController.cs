using Microsoft.AspNetCore.Mvc;
using MsaterResumeIR.Presentation.Controllers;
using RashaPrimeWeb.Application.CQRS.Blog.Commands.CreateBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Commands.UpdateBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;

namespace RashaPrimeWeb.Presentation.Controllers;

public class BlogController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetBlogDto>> GetBlog()
    {
        var query = new GetAllBlogQuery(null, false, 1, 2);
        var query1 = new GetBlogQuery(3);
        var model = await Mediator.Send(query1);


        return Content("completed");
    }
    [HttpGet]
    public async Task<IActionResult> CreateBlog()
    {
        var model = new UpdateBlogCommand();
        model.Id = 3;
        model.Lang_Id = 1;
        model.LinkKey = "aa";
        model.LongTitle = "asssssssssa3";
        model.Seen = 1;
        model.ShortTitle = "1";
        model.Text = "1";
        model.TitleBrowser = "1sssssssssssss";

        //      model.Name = "test" + new Random().Next(1111, 9999);
        var query = await Mediator.Send(model);
        return Content("");
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog(CreateBlogCommand model)
    {
        model.Lang_Id = 1;
        model.LinkKey = "aa";
        model.LongTitle = "aa";
        model.Seen = 1;
        model.ShortTitle = "1";
        model.Text = "1";
        model.TitleBrowser = "1";

        //      model.Name = "test" + new Random().Next(1111, 9999);
        var query = await Mediator.Send(model);
        if (query.IsError)
        {
            return Content("dont created");
        }
        return Content("created");
    }

}
