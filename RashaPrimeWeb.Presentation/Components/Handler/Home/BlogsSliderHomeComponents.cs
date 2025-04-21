using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Presentation;

namespace RashaPrimeWeb.WEB.Components.Main
{
    public class BlogsSliderHomeComponents(IMediator mediator) : ViewComponent
    {
       
   
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            int Take = 5;
            int Page = 1;
            bool GetOldest = false;
            var queryBlog = new GetAllBlogQuery(null, GetOldest, Page, Take);
            var Blog = await mediator.Send(queryBlog);
            
            return View("/Components/Views/Home/Blogs.cshtml", Blog);
        }

    }
}
