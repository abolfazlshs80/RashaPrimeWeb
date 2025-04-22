using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using RashaPrimeWeb.Application.Models.ViewModel.Resource;


public static class UserExtention
{




    public static string GetUserId(this ClaimsPrincipal user)
    {
        var Id = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return string.IsNullOrEmpty(Id) ? string.Empty : Id;
    }


}

