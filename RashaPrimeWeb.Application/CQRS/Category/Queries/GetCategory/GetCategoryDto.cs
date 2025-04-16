using AutoMapper;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.CQRS.Category.Queries.GetCategory;

public record GetCategoryDto(int Id, string Name) : IMapFrom<Domain.Entities.Category>
{
    public GetCategoryDto() : this(0, "") { }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, GetCategoryDto>()
          .ReverseMap();
    }
}
