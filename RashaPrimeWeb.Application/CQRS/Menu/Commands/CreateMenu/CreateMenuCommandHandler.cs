using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RashaPrimeWeb.Application.CQRS.Menu.Commands.CreateMenu;
//[FromKeyedServices("EF")] IMenuRepository repMenu
public class CreateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateMenuCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateMenuCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Menu>();

            var Menu = new Domain.Entities.Menu()
            {
                StatusInUserFooterMenu = request.StatusInUserFooterMenu,
                Title = request.Title,
                Href = request.Href,
                Order = request.Order,
                StatusInFooter = request.StatusInFooter,
                StatusInMainMenu = request.StatusInMainMenu,
                StatusInUserMenu = request.StatusInUserMenu,
                StatusInAdminMenu = request.StatusInAdminMenu,
                RoleName = request.RoleName,
                Icons = request.Icons,
                ControllerName = request.ControllerName,
                Lang_Id = request.Lang_Id,
            };


            await currentRep.AddAsync(Menu);

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