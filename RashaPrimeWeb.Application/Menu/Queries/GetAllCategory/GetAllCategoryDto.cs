using AutoMapper;
using RashaPrimeWeb.Application.Common.Mappings;
using RashaPrimeWeb.Application.Common.Models;

namespace RashaPrimeWeb.Application.Menu.Queries.GetAllCategory;

public record GetAllCategoryDto: IMapFrom<Domain.Entities.Category>
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
        profile.CreateMap<Domain.Entities.Category, GetAllCategoryDto>()
          .ReverseMap();

        profile.CreateMap<PaginatedResult<Domain.Entities.Category>, PaginatedResult<GetAllCategoryDto>>()
            .ReverseMap();
    }
}
