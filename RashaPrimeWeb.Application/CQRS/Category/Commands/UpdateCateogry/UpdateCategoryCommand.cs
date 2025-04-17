using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.CQRS.Category.Commands.UpdateCateogry;

public record UpdateCategoryCommand(int? Id, string Name) : IRequest<ErrorOr<int>>, IMapFrom<Domain.Entities.Category>
{

    public UpdateCategoryCommand() : this(1, "") { }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Entities.Category, UpdateCategoryCommand>()
            .ReverseMap();
    }
}