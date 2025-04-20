using System.Globalization;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Tag.Queries.GetAllTag;

public class GetAllTagQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllTagQuery, PaginatedResult<GetAllTagDto>>
{



    public async Task<PaginatedResult<GetAllTagDto>> Handle(GetAllTagQuery request,
                                         CancellationToken cancellationToken = default)
    {
        {
            string lang = CultureInfo.CurrentCulture.Name;
            var repTag = unitOfWork.Repository<Domain.Entities.Tag>();
            var query = await repTag.GetAllAsync();

            // فیلتر کردن بر اساس عنوان
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(x => x.Name.Contains(request.Title));
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
                .Select(LastTag => new GetAllTagDto
                {
                    Id = LastTag.Id,
                    Name = LastTag.Name,
   
                })
                .ToListAsync(cancellationToken);

            // مپ کردن داده‌ها به GetAllCategoryDto
            // var mappedItems = mapper.Map<List<GetAllTagDto>>(items);



            // بازگرداندن نتیجه
            return new PaginatedResult<GetAllTagDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };



            //  var query =await repTag.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
            //var query=unitOfWork.re
            //  var newmodel = mapper.Map<PaginatedResult<GetAllTagDto>>(query);
            // return newmodel;

        }
    }
}

