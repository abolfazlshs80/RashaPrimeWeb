using AutoMapper;
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
        try
        {
            var currentRep = unitOfWork.GenericCategoryRepository;

            var Category = mapper.Map<Domain.Entities.Category>(request);
            var GetCategoryById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetCategoryById == null)
            {
                Category.Id =0;
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
 
    }
}