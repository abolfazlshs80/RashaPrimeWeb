using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Domain.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

public class GetMenuQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetMenuQuery, GetMenuDto>
{



    public async Task<GetMenuDto> Handle(GetMenuQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repMenu = unitOfWork.Repository<Domain.Entities.Menu>();

        
        var LastMenu = await repMenu
            .GetByIdAsync(request.Id);
        var mappingMenu = new GetMenuDto();

        #region Mapping

        mappingMenu.StatusInUserFooterMenu = LastMenu.StatusInUserFooterMenu;
        mappingMenu.Title = LastMenu.Title;
        mappingMenu.Href = LastMenu.Href;
        mappingMenu.Order = LastMenu.Order;
        mappingMenu.StatusInFooter = LastMenu.StatusInFooter;
        mappingMenu.StatusInMainMenu = LastMenu.StatusInMainMenu;
        mappingMenu.StatusInUserMenu = LastMenu.StatusInUserMenu;
        mappingMenu.StatusInAdminMenu = LastMenu.StatusInAdminMenu;
        mappingMenu.RoleName = LastMenu.RoleName;
        mappingMenu.Icons = LastMenu.Icons;
        mappingMenu.ControllerName = LastMenu.ControllerName;
        mappingMenu.Lang_Id = LastMenu.Lang_Id;

        #endregion


        return mappingMenu;

    }

}