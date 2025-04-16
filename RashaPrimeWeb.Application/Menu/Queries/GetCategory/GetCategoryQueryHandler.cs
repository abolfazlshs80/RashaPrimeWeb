using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.Menu.Queries.GetCategory;

public class GetCategoryQueryHandler( ICategoryRepository repCategory, IMapper mapper)
    : IRequestHandler<GetCategoryQuery, GetCategoryDto>
{

  

    public async Task<GetCategoryDto> Handle(GetCategoryQuery request,
                                         CancellationToken cancellationToken = default)

    {

        var x=await repCategory
            .GetByIdAsync(request.Id);
        return  mapper.Map<GetCategoryDto>(x);
          
    }
     
}