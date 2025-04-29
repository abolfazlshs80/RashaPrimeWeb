using AutoMapper;
using Kashi_Seramic.MVC.Models;
using RashaPrimeWeb.Application.CQRS.Blog.Commands.UpdateBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;
using RashaPrimeWeb.Application.CQRS.Blog.Queries.GetBlog;

namespace RashaPrimeWeb.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<GetBlogDto, UpdateBlogCommand>().ReverseMap();
            #region Tables



            //CreateMap<TableInfoAdminVM, RoleVM>()
            //    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.ID))
            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => (src.Id.ToString()))).ReverseMap();


            //CreateMap<TableInfoAdminVM, Employee>()
            //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => (src.Id.ToString())))
            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Title)).ReverseMap();

            CreateMap<GetAllBlogDto, TableInfoAdminVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ShortTitle))
                //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));
            //CreateMap<NewsVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ShortTitle))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.FileToNews.FirstOrDefault().FileManager.Path));

            //CreateMap<SliderVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.PathImage));

            //CreateMap<MenuVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));


            //CreateMap<FaqVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FullName))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            //CreateMap<TagVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            //CreateMap<ServiceVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.TitleBrowser))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));



            //CreateMap<CommentToBlogVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.FullName))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.Sugestion, opt => opt.MapFrom(src => false));

            //CreateMap<CategoryVM, TableInfoAdminVM>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.LastModifiedDate))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.Sugestion, opt => opt.MapFrom(src => src.IsSugestionHomePage));
            #endregion

        }
    }

}
