using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Blog.Queries.GetAllBlog;

public class GetAllBlogQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllBlogQuery, PaginatedResult<GetAllBlogDto>>
{



    public async Task<PaginatedResult<GetAllBlogDto>> Handle(GetAllBlogQuery request,
                                         CancellationToken cancellationToken = default)
    {
        var repBlog = unitOfWork.Repository<Domain.Entities.Blog>();
        var query =  repBlog.GetAllWithIncludes(query => 
            query.Include(a => a.FileToBlog)
                .ThenInclude(a => a.FileManager));

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
            .Select(LastBlog => new GetAllBlogDto
            {
                Id = LastBlog.Id,
                TitleBrowser = LastBlog.TitleBrowser,
                LinkKey = LastBlog.LinkKey,
                LongTitle = LastBlog.LongTitle,
                ShortTitle = LastBlog.ShortTitle,
                Lang_Id = LastBlog.Lang_Id,
                Seen = LastBlog.Seen,
                ImagePath = LastBlog.FileToBlog.FirstOrDefault().FileManager.Path
            })
            .ToListAsync(cancellationToken);

        // مپ کردن داده‌ها به GetAllCategoryDto
        // var mappedItems = mapper.Map<List<GetAllBlogDto>>(items);



        // بازگرداندن نتیجه
        return new PaginatedResult<GetAllBlogDto>
        {
            Items = items,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalItems = totalItems
        };



        //  var query =await repBlog.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
        //var query=unitOfWork.re
        //  var newmodel = mapper.Map<PaginatedResult<GetAllBlogDto>>(query);
        // return newmodel;

    }

}

