using System.Globalization;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Language.Queries.GetAllLanguage;

public class GetAllLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllLanguageQuery, PaginatedResult<GetAllLanguageDto>>
{



    public async Task<PaginatedResult<GetAllLanguageDto>> Handle(GetAllLanguageQuery request,
                                         CancellationToken cancellationToken = default)
    {
        {
            string lang = CultureInfo.CurrentCulture.Name;
            var repLanguage = unitOfWork.Repository<Domain.Entities.Language>();
            var query = await repLanguage.GetAllAsync();

            // فیلتر کردن بر اساس عنوان
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(x => x.Title.Contains(request.Title));
            }

            // مرتب‌سازی بر اساس قدیمی‌ترین یا جدیدترین
            query = request.GetOldest
                ? query.OrderBy(x => x.Lang_Id)
                : query.OrderByDescending(x => x.Lang_Id);

            // محاسبه تعداد کل آیتم‌ها
            var totalItems = await query.CountAsync(cancellationToken);

            // صفحه‌بندی
            var items = await query

                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(LastLanguage => new GetAllLanguageDto
                {
                    Lang_Id = LastLanguage.Lang_Id,
                    Title = LastLanguage.Title,
                    LanguageTitle = LastLanguage.LanguageTitle,
   
                })
                .ToListAsync(cancellationToken);

            // مپ کردن داده‌ها به GetAllCategoryDto
            // var mappedItems = mapper.Map<List<GetAllLanguageDto>>(items);



            // بازگرداندن نتیجه
            return new PaginatedResult<GetAllLanguageDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };



            //  var query =await repLanguage.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
            //var query=unitOfWork.re
            //  var newmodel = mapper.Map<PaginatedResult<GetAllLanguageDto>>(query);
            // return newmodel;

        }
    }
}

