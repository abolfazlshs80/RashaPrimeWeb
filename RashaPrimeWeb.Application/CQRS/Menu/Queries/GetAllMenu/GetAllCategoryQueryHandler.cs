using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

using RashaPrimeWeb.Application.Common.Models;

using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Menu.Queries.GetAllMenu;

public class GetAllMenuQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllMenuQuery, PaginatedResult<GetAllMenuDto>>
{



    public async Task<PaginatedResult<GetAllMenuDto>> Handle(GetAllMenuQuery request,
                                         CancellationToken cancellationToken = default)
    {
        var repMenu = unitOfWork.Repository<Domain.Entities.Menu>();
        var query = await repMenu.GetAllAsync();

        // فیلتر کردن بر اساس عنوان
        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            query = query.Where(x => x.Title.Contains(request.Title));
        }

        // مرتب‌سازی بر اساس قدیمی‌ترین یا جدیدترین
        query = request.GetOldest
            ? query.OrderBy(x => x.Id)
            : query.OrderByDescending(x => x.Id);

        // محاسبه تعداد کل آیتم‌ها
        var totalItems = await query.CountAsync(cancellationToken);

        // صفحه‌بندی
        var items = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        // مپ کردن داده‌ها به GetAllCategoryDto
        var mappedItems = mapper.Map<List<GetAllMenuDto>>(items);

        // بازگرداندن نتیجه
        return new PaginatedResult<GetAllMenuDto>
        {
            Items = mappedItems,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalItems = totalItems
        };



        //  var query =await repMenu.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
        //var query=unitOfWork.re
        //  var newmodel = mapper.Map<PaginatedResult<GetAllMenuDto>>(query);
        // return newmodel;

    }

}

