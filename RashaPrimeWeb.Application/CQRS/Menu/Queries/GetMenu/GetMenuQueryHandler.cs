using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetMenu;

public class GetMenuQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetMenuQuery, GetMenuDto>
{



    public async Task<GetMenuDto> Handle(GetMenuQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repMenu = unitOfWork.Repository<Domain.Entities.Menu>();
        var x = await repMenu
            .GetByIdAsync(request.Id);
        return mapper.Map<GetMenuDto>(x);

    }

}