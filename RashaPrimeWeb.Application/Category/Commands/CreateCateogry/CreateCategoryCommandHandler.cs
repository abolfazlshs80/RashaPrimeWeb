﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Category.Commands.CreateUser;
//[FromKeyedServices("EF")] ICategoryRepository repCategory
//IRepository<Domain.Entities.Category> repCategory
public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, int>
{
  

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {
        var currentRep = unitOfWork.Repository<Domain.Entities.Category>();

        var Category = mapper.Map<Domain.Entities.Category>(request);
        var GetCategoryById =await currentRep.GetByIdAsync(request.Id,cancellationToken);
        if (GetCategoryById==null)
        {
            await currentRep.AddAsync(Category);
        }
        else
        {
            await currentRep.UpdateAsync(Category);
        }

        await unitOfWork.SaveChangesAsync();
        //order
        //notifacation

        return Category.Id;
    }
}