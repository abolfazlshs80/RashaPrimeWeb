using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Menu.Commands.UpdateMenu;
//[FromKeyedServices("EF")] IMenuRepository repMenu
public class UpdateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateMenuCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Menu>();

            var Menu = mapper.Map<Domain.Entities.Menu>(request);



            await currentRep.UpdateAsync(Menu);



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