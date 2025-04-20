using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Domain.Interface;

namespace RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;

public class GetSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetSettingQuery, GetSettingDto>
{



    public async Task<GetSettingDto> Handle(GetSettingQuery request,
                                         CancellationToken cancellationToken = default)

    {
        var repSetting = unitOfWork.Repository<Domain.Entities.Setting>();

        
        var LastSetting = await repSetting
            .GetAllWithIncludes(null,null).FirstOrDefaultAsync();
        var mappingSetting = new GetSettingDto();

        #region Mapping


       mappingSetting.Title = LastSetting.Title;
       mappingSetting.AboutText = LastSetting.AboutText;
       mappingSetting.AddressCompany = LastSetting.AddressCompany;
       mappingSetting.CityCompany = LastSetting.CityCompany;
       mappingSetting.Lang_Id = LastSetting.Lang_Id;
       mappingSetting.Desc = LastSetting.Desc;
       mappingSetting.DeveloperLinkName = LastSetting.DeveloperLinkName;
       mappingSetting.DeveloperName = LastSetting.DeveloperName;
       mappingSetting.Email = LastSetting.Email;
       mappingSetting.FotterDesc = LastSetting.FotterDesc;
       mappingSetting.Gmail = LastSetting.Gmail;
       mappingSetting.GmailPassword = LastSetting.GmailPassword;
       mappingSetting.AboutText = LastSetting.AboutText;
       mappingSetting.InstagramUserName = LastSetting.InstagramUserName;
       mappingSetting.IsContactUsForHomePage = LastSetting.IsContactUsForHomePage;
       mappingSetting.IsListOfBlogForHomePage = LastSetting.IsListOfBlogForHomePage;
       mappingSetting.IsListOfFaqForHomePage = LastSetting.IsListOfFaqForHomePage;
       mappingSetting.IsListOfNewsForHomePage = LastSetting.IsListOfNewsForHomePage;
       mappingSetting.IsListOfServiceForHomePage = LastSetting.IsListOfServiceForHomePage;
       mappingSetting.IsListOfSliderForHomePage = LastSetting.IsListOfSliderForHomePage;
       mappingSetting.IsListOfStartUpForHomePage = LastSetting.IsListOfStartUpForHomePage;
       mappingSetting.LogoPath = LastSetting.LogoPath;
       mappingSetting.MapCode = LastSetting.MapCode;
       mappingSetting.OwnerName = LastSetting.OwnerName;
       mappingSetting.Phone1 = LastSetting.Phone1;
       mappingSetting.Phone2 = LastSetting.Phone2;
       mappingSetting.SitePath = LastSetting.SitePath;
       mappingSetting.TelegramChannle = LastSetting.TelegramChannle;
       mappingSetting.TelegramNumber = LastSetting.TelegramNumber;
       mappingSetting.TitleDesc = LastSetting.TitleDesc;
       mappingSetting.WhatappNumber = LastSetting.WhatappNumber;


        #endregion


        return mappingSetting;

    }

}