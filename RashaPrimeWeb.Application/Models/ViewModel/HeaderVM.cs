



using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

public class HeaderVM
{
    public GetSettingDto Setting { get; set; }
    public PaginatedResult<GetAllMenuDto> Menu { get; set; }
    //public IEnumerable<LanguagesVM>  Languages { get; set; }  
    //public IEnumerable<BlogVM>  Blogs { get; set; }  
    //public IEnumerable<ServiceVM>  Service { get; set; }  
    //public IEnumerable<CategoryVM>  Categories { get; set; }  

    //public IEnumerable<MenuVM> Menu { get; set; }    
    //public IEnumerable<TagVM> Tag { get; set; }    
}

