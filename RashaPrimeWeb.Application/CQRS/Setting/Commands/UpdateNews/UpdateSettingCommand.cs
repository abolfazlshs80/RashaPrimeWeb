using MediatR;
using RashaPrimeWeb.Application.Models.Models;

namespace RashaPrimeWeb.Application.CQRS.Setting.Commands.UpdateNews;

public record UpdateSettingCommand : BaseDTO, IRequest<ErrorOr<int>>
{

    public string Email { get; set; }
    public string? CityCompany { get; set; }
    public string DeveloperLinkName { get; set; }
    public bool IsListOfSliderForHomePage { get; set; }
    public bool IsListOfBlogForHomePage { get; set; }
    public bool IsListOfNewsForHomePage { get; set; }
    public bool IsListOfServiceForHomePage { get; set; }
    public bool IsListOfStartUpForHomePage { get; set; }
    public bool IsListOfFaqForHomePage { get; set; }
    public bool IsContactUsForHomePage { get; set; }

    public string MapCode { get; set; }
    public string Title { get; set; }
    public string Desc { get; set; }
    public string FotterDesc { get; set; }
    public string TitleDesc { get; set; }
    public string DeveloperName { get; set; }
    public string OwnerName { get; set; }
    public string AddressCompany { get; set; }
    public string TelegramChannle { get; set; }
    public string TelegramNumber { get; set; }
    public string WhatappNumber { get; set; }
    public string InstagramUserName { get; set; }
    public string Gmail { get; set; }
    public string GmailPassword { get; set; }
    public string SitePath { get; set; }
    public string? LogoPath { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? AboutText { get; set; }

    public int? Lang_Id { get; set; }

}