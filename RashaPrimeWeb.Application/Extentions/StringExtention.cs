
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public static class StringExtention
{
	public static string SetForUrl(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return string.Empty;
		}
		return str.Replace(" ", "-");
	}
	public static string SetUserImageProfile(this string str)
	{
		var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "User", $"{str}.jpg");
		if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "User", $"{str}.jpg")))
		{
			return $"/Images/User/{str}.jpg?ver=1.1.1";
		}
		return "/Kashi_Files/assets/images/inner-page/user/1.jpg";

	}
	public static string RemoveDahst(this string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return string.Empty;
		}
		return str.Replace("-", " ");
	}
    public static string ForCategoryUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/Category/"+str;

    }
    //public static string ForTagUrl(this string str)
    //{
    //    if (string.IsNullOrEmpty(str))
    //    {
    //        return string.Empty;
    //    }

    //    str = str.Replace(" ", "-");

    //    return "/Tag/" + str;

    //}
    public static string ForTagUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/Tag/" + str;

    }
    public static string ForBlogUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/Blog/" + str;

    }
    public static string ImageForBlogUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/Images/Blog/" + str;

    }
    public static string ImageForSliderUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }


        return "/Images/Slider/" + str;

    }
    public static string ImageForNewsUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }


        return "/Images/News/" + str;

    }
    public static string ForNewsUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/News/" + str;

    }
    public static string ForServiceUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        str = str.Replace(" ", "-");

        return "/Service/" + str;

    }
    public static string ImageForServiceUrl(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }


        return "/Images/Service/" + str;

    }
   

	public static string SetForProductUrl(this string str)
	{
		return $"/Images/Product/{str}";
		//      var Fileservice = new FileLocalService();
		//return Fileservice.DownloadFile(str, "Product");


	}
    public static string SetForBlogUrl(this string str)
    {
        return $"/Images/Product/{str}";
        //      var Fileservice = new FileLocalService();
        //return Fileservice.DownloadFile(str, "Product");



    }

    public static string SetForLogoUrl(this string str)
    {
        return $"/Images/Logo/{str}";
    }
    public static string SetForProductBackUrl(this string str)
	{
		return $"/Images/Product/{str.Replace("Slider", "BG")}";
		//      var Fileservice = new FileLocalService();
		//return Fileservice.DownloadFile(str.Replace("Slider", "BG"), "Product");


	}

	public static string ForName(this string str)
	{
		return "Model." + str;
	}
}

