using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Category.Queries.GetAllCategory;

public class GetAllCategoryQueryHandler(ICategoryRepository repCategory, IMapper mapper)
    : IRequestHandler<GetAllCategoryQuery, PaginatedResult<GetAllCategoryDto>>
{



    public async Task<PaginatedResult<GetAllCategoryDto>> Handle(GetAllCategoryQuery request,
                                         CancellationToken cancellationToken = default)

    {

        var query = await repCategory.GetAllAsync(request.Title, request.GetOldest, request.PageNumber, request.PageSize);

        var newmodel = mapper.Map<PaginatedResult<GetAllCategoryDto>>(query);
        return newmodel;

    }

}