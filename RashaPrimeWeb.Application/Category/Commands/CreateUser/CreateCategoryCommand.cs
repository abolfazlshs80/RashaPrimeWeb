using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.Category.Commands.CreateUser;

public record CreateCategoryCommand(string Name) : IRequest<int>, IMapFrom<Domain.Entities.Category>
{

    public CreateCategoryCommand() : this("") { }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, CreateCategoryCommand>()
            .ReverseMap();
    }
}