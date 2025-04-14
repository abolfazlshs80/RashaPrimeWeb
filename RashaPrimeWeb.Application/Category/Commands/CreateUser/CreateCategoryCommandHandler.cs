using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Category.Commands.CreateUser;
//[FromKeyedServices("EF")] ICategoryRepository repCategory
//IRepository<Domain.Entities.Category> repCategory
public class CreateCategoryCommandHandler([FromKeyedServices("Dapper")] ICategoryRepository repCategory, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, int>
{
  

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {


        var Category = mapper.Map<Domain.Entities.Category>(request);
        await repCategory.AddAsync(Category);

        //order
        //notifacation

        return Category.CategoryId;
    }
}