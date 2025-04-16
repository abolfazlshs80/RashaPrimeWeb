using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.Menu.Commands.CreateCateogry;

public record CreateMenuCommand(int Id,string Name) : IRequest<ErrorOr<int>>, IMapFrom<Domain.Entities.Menu>
{

    public CreateMenuCommand() : this(1,"") { }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Menu, CreateMenuCommand>()
            .ReverseMap();
    }
}