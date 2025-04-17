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

            var Menu = await currentRep.GetByIdAsync(request.Id);

            Menu.StatusInUserFooterMenu = request.StatusInUserFooterMenu;
            Menu.Title = request.Title;
            Menu.Href = request.Href;
            Menu.Order = request.Order;
            Menu.StatusInFooter = request.StatusInFooter;
            Menu.StatusInMainMenu = request.StatusInMainMenu;
            Menu.StatusInUserMenu = request.StatusInUserMenu;
            Menu.StatusInAdminMenu = request.StatusInAdminMenu;
            Menu.RoleName = request.RoleName;
            Menu.Icons = request.Icons;
            Menu.ControllerName = request.ControllerName;
            Menu.Lang_Id = request.Lang_Id;





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