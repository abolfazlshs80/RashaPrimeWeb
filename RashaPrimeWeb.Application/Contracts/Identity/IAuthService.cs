using RashaPrimeWeb.Application.Models.Identity.Authentication;
using RashaPrimeWeb.Domain.Enums;

namespace RashaPrimeWeb.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginDto request);
        Task<RegisterResult> Register(RegisterDto request);
        Task<string> ForgotPassWord(FrogotPasswordDto request);
        Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request);
        Task<bool> ConfirmEmail(ConfirmEmailDto request);

        Task<bool> Logout(string id);

    }
}
