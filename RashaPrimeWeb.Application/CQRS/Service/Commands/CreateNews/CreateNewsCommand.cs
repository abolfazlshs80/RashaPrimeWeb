using MediatR;

namespace RashaPrimeWeb.Application.CQRS.Service.Commands.CreateNews;

public record CreateServiceCommand : IRequest<ErrorOr<int>>
{

    public string TitleBrowser { get; set; }

    public string ShortTitle { get; set; }

    public string LongTitle { get; set; }

    public string Text { get; set; }

    public int Seen { get; set; }
    public int ServiceType { get; set; }
    public decimal PriceModel { get; set; }
    public string LinkKey { get; set; }
    //(فناوری‌های استفاده شده، متنی)
    public string TechnologyStack { get; set; }
    // (نام یا شناسه مسئول سرویس، متنی یا عددی)
    public string ServiceOwner { get; set; }
    // (اطلاعات تماس پشتیبانی، متنی)
    public string SupportContact { get; set; }
    //(ویژگی‌های کلیدی سرویس، متنی)
    public string KeyFeatures { get; set; }
    // (مدل درآمدزایی، متنی)
    public string RevenueModel { get; set; }
    //(شرکای مرتبط با سرویس، متنی)
    public string Partnerships { get; set; }

    public int? Lang_Id { get; set; }


}