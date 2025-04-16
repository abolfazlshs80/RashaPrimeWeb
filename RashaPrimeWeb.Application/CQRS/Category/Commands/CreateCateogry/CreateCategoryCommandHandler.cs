using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Category.Commands.CreateCateogry;
//[FromKeyedServices("EF")] ICategoryRepository repCategory
public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Category>();

            var Category = mapper.Map<Domain.Entities.Category>(request);
         
            if (Category.Id == 0)
            {
      
                await currentRep.AddAsync(Category);
            }
            else
            {
                await currentRep.UpdateAsync(Category);
            }

            await unitOfWork.SaveChangesAsync();
            //order

            return Category.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}