using System.Globalization;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Common.Models;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Slider.Queries.GetAllSlider;

public class GetAllSliderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllSliderQuery, PaginatedResult<GetAllSliderDto>>
{



    public async Task<PaginatedResult<GetAllSliderDto>> Handle(GetAllSliderQuery request,
                                         CancellationToken cancellationToken = default)
    {
        {
            string lang = CultureInfo.CurrentCulture.Name;
            var repSlider = unitOfWork.Repository<Domain.Entities.Slider>();
            var query = await repSlider.GetAllAsync();

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
                .Select(LastSlider => new GetAllSliderDto
                {
                    Id = LastSlider.Id,
                    Title = LastSlider.Title,
                    PathImage = LastSlider.PathImage,
                    Order = LastSlider.Order,

                    Text = LastSlider.Text,
                    Lang_Id = LastSlider.Lang_Id,

                })
                .ToListAsync(cancellationToken);

            // مپ کردن داده‌ها به GetAllCategoryDto
            // var mappedItems = mapper.Map<List<GetAllSliderDto>>(items);



            // بازگرداندن نتیجه
            return new PaginatedResult<GetAllSliderDto>
            {
                Items = items,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };



            //  var query =await repSlider.GetAllAsync(request.Title,request.GetOldest,request.PageNumber,request.PageSize);
            //var query=unitOfWork.re
            //  var newmodel = mapper.Map<PaginatedResult<GetAllSliderDto>>(query);
            // return newmodel;

        }
    }
}

