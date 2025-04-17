using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.CQRS.Category.Commands.CreateCateogry;

public record CreateCategoryCommand(int? Id, string Name) : IRequest<ErrorOr<int>>, IMapFrom<Domain.Entities.Category>
{

    public CreateCategoryCommand() : this(1, "") { }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, CreateCategoryCommand>()
            .ReverseMap();
    }
}