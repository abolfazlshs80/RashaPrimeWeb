using AutoMapper;
using MediatR;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Setting.Commands.UpdateNews;
//[FromKeyedServices("EF")] ISettingRepository repSetting
public class UpdateSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateSettingCommand, ErrorOr<int>>
{


    public async Task<ErrorOr<int>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var currentRep = unitOfWork.Repository<Domain.Entities.Setting>();

            var Setting = await currentRep.GetByIdAsync(request.Id);



            Setting.Title = request.Title;
            Setting.AboutText = request.AboutText;
            Setting.AddressCompany = request.AddressCompany;
            Setting.CityCompany = request.CityCompany;
            Setting.Lang_Id = request.Lang_Id;
            Setting.Desc = request.Desc;
            Setting.DeveloperLinkName = request.DeveloperLinkName;
            Setting.DeveloperName = request.DeveloperName;
            Setting.Email = request.Email;
            Setting.FotterDesc = request.FotterDesc;
            Setting.Gmail = request.Gmail;
            Setting.GmailPassword = request.GmailPassword;
            Setting.AboutText = request.AboutText;
            Setting.InstagramUserName = request.InstagramUserName;
            Setting.IsContactUsForHomePage = request.IsContactUsForHomePage;
            Setting.IsListOfBlogForHomePage = request.IsListOfBlogForHomePage;
            Setting.IsListOfFaqForHomePage = request.IsListOfFaqForHomePage;
            Setting.IsListOfNewsForHomePage = request.IsListOfNewsForHomePage;
            Setting.IsListOfServiceForHomePage = request.IsListOfServiceForHomePage;
            Setting.IsListOfSliderForHomePage = request.IsListOfSliderForHomePage;
            Setting.IsListOfStartUpForHomePage = request.IsListOfStartUpForHomePage;
            Setting.LogoPath = request.LogoPath;
            Setting.MapCode = request.MapCode;
            Setting.OwnerName = request.OwnerName;
            Setting.Phone1 = request.Phone1;
            Setting.Phone2 = request.Phone2;
            Setting.SitePath = request.SitePath;
            Setting.TelegramChannle = request.TelegramChannle;
            Setting.TelegramNumber = request.TelegramNumber;
            Setting.TitleDesc = request.TitleDesc;
            Setting.WhatappNumber = request.WhatappNumber;



            await currentRep.UpdateAsync(Setting);



            await unitOfWork.SaveChangesAsync();
            //order

            return Setting.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Validation(e?.InnerException?.Message);


        }

    }
}