using OurResumeIR.Application.ViewModels.Account;
using RashaPrimeWeb.Domain.Enums;

namespace RashaPrimeWeb.Application.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginUser(LoginViewModel model);
        Task<RegisterResult> RegisterUser(RegisterViewModel viewModel);
    }
}
