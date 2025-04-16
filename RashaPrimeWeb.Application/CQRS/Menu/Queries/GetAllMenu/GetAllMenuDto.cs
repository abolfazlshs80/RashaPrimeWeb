using AutoMapper;
using RashaPrimeWeb.Application.Common.Mappings;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;

public class GetAllMenuDto : IMapFrom<Domain.Entities.Menu>
{
    public bool StatusInUserFooterMenu { get; set; }
    public string Title { get; set; }
    public string Href { get; set; }
    public int Order { get; set; }

    public string RoleName { get; set; }
    public string Icons { get; set; }
    public string ControllerName { get; set; }

    public int? Lang_Id { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Menu, GetAllMenuDto>()
          .ReverseMap();

        //profile.CreateMap<PaginatedResult<Domain.Entities.Menu>, PaginatedResult<GetAllMenuDto>>()
        //    .ReverseMap();
    }
}
