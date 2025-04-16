using AutoMapper;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

public record GetMenuDto : IMapFrom<Domain.Entities.Menu>
{
    public bool StatusInUserFooterMenu { get; set; }
    public string Title { get; set; }
    public string Href { get; set; }
    public int Order { get; set; }
    public bool StatusInFooter { get; set; }

    public bool StatusInMainMenu { get; set; }

    public bool StatusInUserMenu { get; set; }

    public bool StatusInAdminMenu { get; set; }
    public string RoleName { get; set; }
    public string Icons { get; set; }
    public string ControllerName { get; set; }

    public int? Lang_Id { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Menu, GetMenuDto>()
          .ReverseMap();
    }
}
