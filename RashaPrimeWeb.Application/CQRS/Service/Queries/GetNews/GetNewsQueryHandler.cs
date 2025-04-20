using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Service.Queries.GetNews;

public class GetServiceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetServiceQuery, GetServiceDto>
{



    public async Task<GetServiceDto> Handle(GetServiceQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repService = unitOfWork.Repository<Domain.Entities.Service>();

        
        var LastService = await repService
            .GetByIdAsync(request.Id);
        var mappingService = new GetServiceDto();

        #region Mapping

        mappingService.TitleBrowser = LastService.TitleBrowser;
        mappingService.LinkKey = LastService.LinkKey;
        mappingService.LongTitle = LastService.LongTitle;
        mappingService.ShortTitle = LastService.ShortTitle;
        mappingService.Lang_Id = LastService.Lang_Id;
        mappingService.Seen = LastService.Seen;

        // مقادیری که در request وجود ندارند و باید به صورت دستی تنظیم شوند
        mappingService.ServiceType = LastService.ServiceType; // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
        mappingService.PriceModel = LastService.PriceModel; // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
        mappingService.TechnologyStack = LastService.TechnologyStack; // یا مقدار پیش‌فرض
        mappingService.ServiceOwner = LastService.ServiceOwner; // یا مقدار پیش‌فرض
        mappingService.SupportContact = LastService.SupportContact; // یا مقدار پیش‌فرض
        mappingService.KeyFeatures = LastService.KeyFeatures; // یا مقدار پیش‌فرض
        mappingService.RevenueModel = LastService.RevenueModel; // یا مقدار پیش‌فرض
        mappingService.Partnerships = LastService.Partnerships; // یا مقدار پیش‌فرض
        #endregion


        return mappingService;

    }

}