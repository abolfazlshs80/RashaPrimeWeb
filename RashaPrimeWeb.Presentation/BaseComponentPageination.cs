using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;

namespace RashaPrimeWeb.Presentation
{
    public class BaseComponentPageination: ViewComponent
    {
        public int Take { get; set; }
        public int Page { get; set; }
        public bool GetOldest { get; set; }
        public virtual  async Task<IViewComponentResult> InvokeAsync()
        {
           

            return View("/Components/Views/Home/Blogs.cshtml");
        }
    }
}
