

using MediatR;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.CQRS.Setting.Queries.GetSetting;


public class PaginationBaseController(IMediator mediator) : Controller


{
	

    public string GetAdminPageViewType(AdminPageViewType type, string title)
	{
		string value;
		if (type == AdminPageViewType.List)
		{
			value = "لیست" + title;

		}

		else if (type == AdminPageViewType.Create)
		{
			value = "ساخت" + title;
		}

		else if (type == AdminPageViewType.Update)
		{
			value = "ویرایش" + title;
		}

		else if (type == AdminPageViewType.Delete)
		{
			value = "حذف" + title;

		}

		else
		{
			value = title;
		}
		return value;
	}
	public string GetAdminPageType(AdminPageType type)
	{
		string value = "";
		if (type == AdminPageType.Blog)
		{
			value = "مقاله";

		}
        else if (type == AdminPageType.News)
        {
            value = "خبر ها";

        }

        else if (type == AdminPageType.Category)
		{
			value = "دسته بندی";

		}

		else if (type == AdminPageType.Setting)
		{
			value = "تنظیمات";

		}

		else if (type == AdminPageType.Filter)
		{
			value = "فیلتر";

		}
		else if (type == AdminPageType.Product)
		{
			value = "محصولات";

		}
		else if (type == AdminPageType.ExampleWork)
		{
			value = "نمونه کار";

		}
		else if (type == AdminPageType.Brand)
		{
			value = "برند";

		}
		else if (type == AdminPageType.Menu)
		{
			value = "منو";

		}
		else if (type == AdminPageType.Slider)
		{
			value = "اسلایدر";

		}
		else if (type == AdminPageType.Tag)
		{
			value = "تگ";

		}
        else if (type == AdminPageType.Comment)
        {
            value = "نظر";

        }
        else if (type == AdminPageType.Service)
        {
            value = "خدمات";

        }
        else if (type == AdminPageType.User)
		{
			value = "کاربر";

		}
		else if (type == AdminPageType.Role)
		{
			value = "مقام";

		}
        else if (type == AdminPageType.Faq)
        {
            value = "سوالات متداول";

        }
        else if (type == AdminPageType.Order)
        {
            value = "سفارش";

        }
        else
		{
			value = " خالی است";
		}
		return value;
	}
	public enum AdminPageViewType
	{
		List,
		Create,
		Update,
		Delete,
		None
	}
	public enum AdminPageType
	{
		Blog,
		Faq,
		News,
		Comment,
		Category,
		Setting,
		Service,
		Filter,
		Product,
		ExampleWork,
		Brand,
		Menu,
		Slider,
		Tag,
		User,
		Role,
		Order
	}
	
	public int Take { get; set; } = 5;
	public int Page { get; set; } = 1;
	public bool GetOldest { get; set; } = false;
	public dynamic list { get; set; }


	public dynamic SetPageInation<T>(int page, IEnumerable<T> list, int take = 5)
	{
		ViewBag.Page = page;
		ViewBag.count = (list.Count() / 5) + 1;
		ViewBag.page = page;
		take = Take;
		return list.Skip(page * Take).Take(Take);
	}

	public async Task SetViewBagAdmin(List<string> keyworks, AdminPageViewType type, AdminPageType pagetype)
    {

        var querySetting = new GetSettingQuery();
     
        var setting = await mediator.Send(querySetting);
        string ControllerName = ControllerContext.ActionDescriptor.ControllerName;
		string ActionName = ControllerContext.ActionDescriptor.ActionName;

		ViewBag.ControllerName = ControllerName;
		ViewBag.Action = ActionName;
		ViewBag.admin = true;
		ViewBag.robot = "noindex,nofollow";
		ViewBag.socialmedia = false;
		ViewBag.title = GetAdminPageViewType(type, $" {GetAdminPageType(pagetype)} ");
		ViewBag.TypePage = GetAdminPageType(pagetype);
		//if (list != null)
		//	ViewBag.keywords = keyworks.Join(",");
		ViewBag.author = setting.OwnerName;
		ViewBag.description = $"این صفحه مربوط به {ViewBag.title} است";
		ViewBag.imageurl = $"{setting.LogoPath.SetForLogoUrl()}";
		ViewBag.link = $"{setting.SitePath}/Admin/{ControllerName}/{ActionName}";
		ViewBag.username = "";


	}

    public void SetLocationBar(bool loc1, string title1, string title2)
    {
        ViewBag.StatusLocationBarOne = loc1;
        ViewBag.StatusLocationBar = true;
        ViewBag.LocationBarOne = title1;
        ViewBag.Title = title2;
        ViewBag.PageDesc = title2;
        ViewBag.Title = title2;
    }
    public void SetViewbag(int count, int page, int id, string type,string link="")
    {
        ViewBag.count = (count / 5) + 1;
        ViewBag.page = page;
        ViewBag.Id = id;
        ViewBag.type = type;
        ViewBag.Link = link;
        ViewBag.PageHeader = type;
    }

    public void SetViewbag(int count, int page, string title, string type, string link = "")
    {
        ViewBag.Id = 0;
        ViewBag.count = (count / 5) + 1;
        ViewBag.page = page;
        ViewBag.title = title;
        ViewBag.Title = title;
        ViewBag.PageHeader = title;

        ViewBag.type = type;
        ViewBag.Link = link;
    }
}

