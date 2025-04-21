using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;
using System.Globalization;

namespace RashaPrimeWeb.Application.CQRS.News.Queries.GetAllNews;

public class GetAllNewsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllNewsQuery, PaginatedResult<GetAllNewsDto>>
{



    public async Task<PaginatedResult<GetAllNewsDto>> Handle(GetAllNewsQuery request,
                                         CancellationToken cancellationToken = default)
    {
        {
            string lang = CultureInfo.CurrentCulture.Name;
            var repNews = unitOfWork.Repository<Domain.Entities.News>();
            var query =  repNews.GetAllWithIncludes(query=>
                query.Include(a=>a.FileToNews)
                    .ThenInclude(a=>a.FileManager));

            // فیلتر کردن بر اساس عنوان
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(x => x.TitleBrowser.Contains(request.Title));
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
                .Select(LastNews => new GetAllNewsDto
                {
                    ImagePath = LastNews.FileToNews.FirstOrDefault().FileManager.Path,
                    TitleBrowser = LastNews.TitleBrowser,
                    LinkKey = LastNews.LinkKey,
                    LongTitle = LastNews.LongTitle,
                    ShortTitle = LastNews.ShortTitle,
                    Lang_Id = LastNews.Lang_Id,
                    Seen = LastNews.Seen,
                })
                .ToListAsync(cancellationToken);

            // مپ کردن داده‌ها به GetAllCategoryDto
            // var mappedItems = mapper.Map<List<GetAllNewsDto>>(items);



            // بازگرداندن نتیجه
            return new PaginatedResult<GetAllNewsDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };



            //  var query =await repNews.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
            //var query=unitOfWork.re
            //  var newmodel = mapper.Map<PaginatedResult<GetAllNewsDto>>(query);
            // return newmodel;

        }
    }
}

