



using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

public class HeaderVM
{
    public GetSettingDto Setting { get; set; }
    public PaginatedResult<GetAllMenuDto> Menu { get; set; }
    //public LanguagesVM  Languages { get; set; }  
    public PaginatedResult<GetAllNewsDto> News { get; set; }
    public PaginatedResult<GetAllBlogDto> Blogs { get; set; }
    public PaginatedResult<GetAllServiceDto> Service { get; set; }
    public PaginatedResult<GetAllCategoryDto> Categories { get; set; }

    //public IEnumerable<TagVM> Tag { get; set; }    
}

