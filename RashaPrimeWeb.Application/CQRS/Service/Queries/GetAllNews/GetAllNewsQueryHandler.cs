using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Service.Queries.GetAllNews;

public class GetAllServiceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllServiceQuery, PaginatedResult<GetAllServiceDto>>
{



    public async Task<PaginatedResult<GetAllServiceDto>> Handle(GetAllServiceQuery request,
                                         CancellationToken cancellationToken = default)
    {
        var repService = unitOfWork.Repository<Domain.Entities.Service>();
        var query =  repService.GetAllWithIncludes(query=>
            query.Include(a=>a.FileToService)
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
            . Select(LastService => new GetAllServiceDto
            {
                ImagePath = LastService.FileToService.FirstOrDefault().FileManager.Path??string.Empty,
                TitleBrowser = LastService.TitleBrowser,
                LinkKey = LastService.LinkKey,
                LongTitle = LastService.LongTitle,
                ShortTitle = LastService.ShortTitle,
                Lang_Id = LastService.Lang_Id,
                Seen = LastService.Seen,

                // مقادیری که در request وجود ندارند و باید به صورت دستی تنظیم شوند
                ServiceType = LastService.ServiceType, // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
                PriceModel = LastService.PriceModel, // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
                TechnologyStack = LastService.TechnologyStack, // یا مقدار پیش‌فرض
                ServiceOwner = LastService.ServiceOwner, // یا مقدار پیش‌فرض
                SupportContact = LastService.SupportContact, // یا مقدار پیش‌فرض
                KeyFeatures = LastService.KeyFeatures, // یا مقدار پیش‌فرض
                RevenueModel = LastService.RevenueModel, // یا مقدار پیش‌فرض
                Partnerships = LastService.Partnerships // یا مقدار پیش‌فرض
            })
            .ToListAsync(cancellationToken);

        // مپ کردن داده‌ها به GetAllCategoryDto
       // var mappedItems = mapper.Map<List<GetAllServiceDto>>(items);
   


        // بازگرداندن نتیجه
        return new PaginatedResult<GetAllServiceDto>
        {
            Items = items,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalItems = totalItems
        };



        //  var query =await repService.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
        //var query=unitOfWork.re
        //  var newmodel = mapper.Map<PaginatedResult<GetAllServiceDto>>(query);
        // return newmodel;

    }

}

