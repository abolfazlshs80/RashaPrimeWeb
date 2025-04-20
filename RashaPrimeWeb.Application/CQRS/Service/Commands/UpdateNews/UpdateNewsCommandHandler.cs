using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Service.Commands.UpdateNews;
//[FromKeyedServices("EF")] IServiceRepository repService
public class UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateServiceCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Service>();

            var Service = await currentRep.GetByIdAsync(request.Id);



            Service.TitleBrowser = request.TitleBrowser;
            Service.LinkKey = request.LinkKey;
            Service.LongTitle = request.LongTitle;
            Service.ShortTitle = request.ShortTitle;
            Service.Lang_Id = request.Lang_Id;
            Service.Text = request.Text;
            Service.Seen = request.Seen;
            // مقادیری که در request وجود ندارند و باید به صورت دستی تنظیم شوند
            Service.ServiceType = request.ServiceType; // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
            Service.PriceModel = request.PriceModel; // مقدار پیش‌فرض یا مقداری که شما تعیین می‌کنید
            Service.TechnologyStack = request.TechnologyStack; // یا مقدار پیش‌فرض
            Service.ServiceOwner = request.ServiceOwner; // یا مقدار پیش‌فرض
            Service.SupportContact = request.SupportContact; // یا مقدار پیش‌فرض
            Service.KeyFeatures = request.KeyFeatures; // یا مقدار پیش‌فرض
            Service.RevenueModel = request.RevenueModel; // یا مقدار پیش‌فرض
            Service.Partnerships = request.Partnerships; // یا مقدار پیش‌فرض


            await currentRep.UpdateAsync(Service);



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