using System.Globalization;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Faq.Queries.GetAllFaq;

public class GetAllFaqQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllFaqQuery, PaginatedResult<GetAllFaqDto>>
{



    public async Task<PaginatedResult<GetAllFaqDto>> Handle(GetAllFaqQuery request,
                                         CancellationToken cancellationToken = default)
    {
        {
            string lang = CultureInfo.CurrentCulture.Name;
            var repFaq = unitOfWork.Repository<Domain.Entities.Faq>();
            var query = await repFaq.GetAllAsync();

            // فیلتر کردن بر اساس عنوان
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(x => x.FullName.Contains(request.Title));
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
                .Select(LastFaq => new GetAllFaqDto
                {
                    Id = LastFaq.Id,
                    Email = LastFaq.Email,
                    FullName = LastFaq.FullName,
                    Phone = LastFaq.Phone,
                    ReplayText = LastFaq.ReplayText,
                    Text = LastFaq.Text,
                    Lang_Id = LastFaq.Lang_Id,

                })
                .ToListAsync(cancellationToken);

            // مپ کردن داده‌ها به GetAllCategoryDto
            // var mappedItems = mapper.Map<List<GetAllFaqDto>>(items);



            // بازگرداندن نتیجه
            return new PaginatedResult<GetAllFaqDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };



            //  var query =await repFaq.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
            //var query=unitOfWork.re
            //  var newmodel = mapper.Map<PaginatedResult<GetAllFaqDto>>(query);
            // return newmodel;

        }
    }
}

