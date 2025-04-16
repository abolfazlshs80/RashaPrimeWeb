﻿using AutoMapper;
using MediatR;

using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Menu.Commands.CreateCateogry;
//[FromKeyedServices("EF")] IMenuRepository repMenu
public class CreateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateMenuCommand, ErrorOr<int>>
{
  

    public async Task<ErrorOr<int>> Handle(CreateMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Menu>();

            var Menu = mapper.Map<Domain.Entities.Menu>(request);
            var GetMenuById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetMenuById == null)
            {
                Menu.Id =0;
                await currentRep.AddAsync(Menu);
            }
            else
            {
                await currentRep.UpdateAsync(Menu);
            }

            await unitOfWork.SaveChangesAsync();
            //order

            return Menu.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);
            
           
        }
 
    }
}