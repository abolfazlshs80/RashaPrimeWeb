using RashaPrimeWeb.Application.Common;

namespace RashaPrimeWeb.Application.Contracts.Infrastructure;

public interface ISmsAdapter
{
    Task<ErrorOr<bool>> SendAsync(string receiver, string text);
}
