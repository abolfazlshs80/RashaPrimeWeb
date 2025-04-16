using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Category.Commands.DeleteCateogry;
//[FromKeyedServices("EF")] ICategoryRepository repCategory
public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteCategoryCommand, ErrorOr<int>>
{
  

    public async Task<ErrorOr<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Category>();

        
            var GetCategoryById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetCategoryById != null)
            {
                await currentRep.DeleteAsync(request.Id);
            }
          

            await unitOfWork.SaveChangesAsync();
            //order
            return request.Id;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e.Message);
            
           
        }
 
    }
}