using AutoMapper;
using MediatR;
using RashaPrimeWeb.Application.Common.Mappings;

namespace RashaPrimeWeb.Application.Category.Commands.DeleteCateogry;

public record DeleteCategoryCommand(int Id) : IRequest<ErrorOr<int>>
{

    public DeleteCategoryCommand() : this(0) { }


}