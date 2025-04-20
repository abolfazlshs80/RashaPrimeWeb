using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Service.Commands.CreateNews;
//[FromKeyedServices("EF")] IServiceRepository repService
public class CreateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateServiceCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(CreateServiceCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Service>();

            var Service = new Domain.Entities.Service()
            {
                TitleBrowser = request.TitleBrowser,
                LinkKey = request.LinkKey,
                LongTitle = request.LongTitle,
                Text = request.Text,
                ShortTitle = request.ShortTitle,
                Lang_Id = request.Lang_Id,
                Seen = request.Seen,

                // مقادیری که در request وجود ندارند و باید به صورت دستی تنظیم شوند
                ServiceType = request.ServiceType, // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
                PriceModel = request.PriceModel, // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
                TechnologyStack = request.TechnologyStack, // یا مقدار پیش‌فرض
                ServiceOwner = request.ServiceOwner, // یا مقدار پیش‌فرض
                SupportContact = request.SupportContact, // یا مقدار پیش‌فرض
                KeyFeatures = request.KeyFeatures, // یا مقدار پیش‌فرض
                RevenueModel = request.RevenueModel, // یا مقدار پیش‌فرض
                Partnerships = request.Partnerships // یا مقدار پیش‌فرض
                //IsDeleted = false,
                //Status = true
            };


            await currentRep.AddAsync(Service);

            await unitOfWork.SaveChangesAsync();
            //order

            return Service.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}