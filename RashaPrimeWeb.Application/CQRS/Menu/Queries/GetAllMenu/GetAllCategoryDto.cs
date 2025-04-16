using AutoMapper;
using RashaPrimeWeb.Application.Common.Mappings;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;

public record GetAllMenuDto : IMapFrom<Domain.Entities.Menu>
{
    public bool IsSugestionHomePage { get; set; }
    public bool IsMenuHomePage { get; set; }
    public string? SVG_Icon { get; set; }
    public string Name { get; set; }
    public string? ShortDesc { get; set; }
    public string? Type { get; set; }
    public string? Text { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Menu, GetAllMenuDto>()
          .ReverseMap();

        profile.CreateMap<PaginatedResult<Domain.Entities.Menu>, PaginatedResult<GetAllMenuDto>>()
            .ReverseMap();
    }
}
