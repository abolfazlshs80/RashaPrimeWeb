using RashaPrimeWeb.Application.Models.Identity.Authentication;
using RashaPrimeWeb.Application.Models.Identity.User;

namespace RashaPrimeWeb.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUser(string userId);
        Task<ErrorOr<UserDto>> UpdateUser(UserDto model);
        Task<ErrorOr<UserDto>> DeleteUser(UserDto model);
        Task<ErrorOr<UserDto>> ChangePasswordUser(ChangePasswordDto model);
    }
}
