using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Menu.Commands.DeleteCateogry;
//[FromKeyedServices("EF")] IMenuRepository repMenu
public class DeleteMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteMenuCommand, ErrorOr<int>>
{
  

    public async Task<ErrorOr<int>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Menu>();

        
            var GetMenuById = await currentRep.GetByIdAsync(request.Id, cancellationToken);
            if (GetMenuById != null)
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