



using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
using RashaPrimeWeb.Application.CQRS.Language.Queries.GetAllLanguage;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;
using RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

public class HeaderVM
{
    public GetSettingDto Setting { get; set; }
    public PaginatedResult<GetAllMenuDto> Menu { get; set; }
    public PaginatedResult<GetAllLanguageDto> Languages { get; set; }  
    public PaginatedResult<GetAllNewsDto> News { get; set; }
    public PaginatedResult<GetAllBlogDto> Blogs { get; set; }
    public PaginatedResult<GetAllServiceDto> Service { get; set; }
    public PaginatedResult<GetAllCategoryDto> Categories { get; set; }

   public PaginatedResult<GetAllTagDto> Tag { get; set; }    
}

