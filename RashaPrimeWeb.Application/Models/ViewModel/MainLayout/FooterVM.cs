



    using RashaPrimeWeb.Application.Common.Models;
    using RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;
    using RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;
    using RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;
    using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

    namespace RashaPrimeWeb.Application.Models.ViewModel.MainLayout; 

    public class FooterVM
    {
        
        public PaginatedResult<GetAllCategoryDto> Categories { get; set; }
    public GetSettingDto Setting { get; set; }
        public PaginatedResult<GetAllMenuDto> Menu { get; set; }
}