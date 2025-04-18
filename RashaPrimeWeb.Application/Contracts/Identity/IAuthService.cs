namespace RashaPrimeWeb.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<string> ForgotPassWord(FrogotPasswordDto request);
        Task<ResetPasswordDto> RessetPassword(ResetPasswordDto request);
        Task<bool> ConfirmEmail(ConfirmEmailDto request);
        Task<ResponseDto> SendTotpCodeStatus(SendTotpCodeDto request);
        Task<SendTotpCodeDto> SendTotpCode(SendTotpCodeDto request);
        Task<VerifyTotpCodeDto> VeryfiyTotpCodeStatus(VerifyTotpCodeDto request);
        Task<VerifyTotpCodeDto> VeryfiyTotpCode(VerifyTotpCodeDto request);
        Task<bool> Logout(string id);

    }
}
