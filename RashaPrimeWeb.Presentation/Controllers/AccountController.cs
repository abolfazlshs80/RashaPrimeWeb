using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RashaPrimeWeb.Application.Contracts.Identity;
using RashaPrimeWeb.Application.Models.Identity.Authentication;
using RashaPrimeWeb.Application.Models.Identity.Role;
using RashaPrimeWeb.Domain.Enums;
using SharedUtilities.Constants;

namespace RashaPrimeWeb.WEB.Controllers
{
    public class AccountController(IHttpContextAccessor _httpContextAccessor, IAuthService _authService, IRoleService _roleService) : Controller
    {



        [HttpGet("/login")]
        [HttpGet("/Users/login")]
        [HttpGet("/Account/login")]
        public async Task<IActionResult> Login(string ReturnUrl = null)
        {
            ViewBag.Title = "ورود";
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { });
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost("/login")]
        [HttpPost("/Users/login")]
        [HttpPost("/Account/login")]
        public async Task<IActionResult> Login(LoginDto model, string ReturnUrl = null)
        {

            if (User.Identity.IsAuthenticated)
            {
                return NotFound();
            }
            ViewBag.ReturnUrl = ReturnUrl;


            var isLoggedIn = await _authService.Login(model);
            if (isLoggedIn == LoginResult.Success)
            {
                //await _notifyHub.Clients.All.SendAsync("Send", "ورود", "با موفقیت  وارد حساب کاربری خود شدید");
                return LocalRedirect(ReturnUrl ?? "/");
            }
            ModelState.AddModelError("", GlogalErrorMessage.Invalid_Password_UserName);
            return View(model);
        }


        [HttpGet("/Logout")]
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _authService.Logout(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return LocalRedirect(returnUrl);

        }
    }
}
