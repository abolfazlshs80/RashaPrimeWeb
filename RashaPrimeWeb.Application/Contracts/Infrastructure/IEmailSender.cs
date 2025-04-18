using RashaPrimeWeb.Application.Models.Infrastructure;

namespace RashaPrimeWeb.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<ErrorOr<bool>> SendEmail(Email email);
    }
}
