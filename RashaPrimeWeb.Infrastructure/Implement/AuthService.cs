using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RashaPrimeWeb.Application.Contracts.Identity;
using RashaPrimeWeb.Application.Models.Identity.Authentication;
using RashaPrimeWeb.Application.Models.Identity.User;
using RashaPrimeWeb.Domain.Enums;

namespace RashaPrimeWeb.Infrastructure.Implement
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly SignInManager<UserApplication> _signInManager;

        public AuthService(UserManager<UserApplication> userManager,
         
            SignInManager<UserApplication> signInManager)
        {
            _userManager = userManager;
         
            _signInManager = signInManager;
           
        }

        public Task<bool> ConfirmEmail(ConfirmEmailDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ForgotPassWord(FrogotPasswordDto request)
        {
            request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                 request.Message = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";
            else
            {

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                return resetPasswordToken;
            }
            //var resetPasswordUrl = Url.Action("ResetPassword", "Account",
            //    new { email = user.Email, token = resetPasswordToken }, Request.Scheme);
            //await sender.SendEmail("بازنشانی رمز عبور ", resetPasswordUrl, email, "پنل مدیریت سایت");
            return "null";
        }

        public async Task<LoginResult> Login(LoginDto request)
        {
        

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return LoginResult.UserNotFound;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            if (result.Succeeded)
            {
                return LoginResult.Success;
            }

            return LoginResult.InvalidPassword;

    
        }

        public async Task<bool> Logout(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.RemoveFromRoleAsync(user, "User");
                await _signInManager.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<RegisterResult> Register(RegisterDto request)
        {
            var userByEmail= await _userManager.FindByEmailAsync(request.Email);
            if (userByEmail!=null)
            {
                return RegisterResult.DupplicateEmail;
            }

            if (request.Password != request.RePassword)
            {
                return RegisterResult.UnequalPassAndRePass;
            }


            var user = new UserApplication
            {
                Email = request.Email,
                UserName = request.Email,

            };

            var status = await _userManager.CreateAsync(user, request.Password);
            if (status.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("CodeMeli", "3"),

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await _signInManager.SignInAsync(user, properties);

            }

            return RegisterResult.Success;
        }

        public async Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return new ResetPasswordDto();
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (result.Succeeded)
            {
                request.Message = "رمزعبور شما با موفقیت تغییر یافت";
                request.Status = true;
            }

            request.Message = "";
            foreach (var error in result.Errors)
            {
                request.Message += error.Description + " , ";
            }

            request.Status = false;

            return request;
        }

    }
}
