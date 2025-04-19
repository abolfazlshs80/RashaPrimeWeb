using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Contracts.Identity;
using RashaPrimeWeb.Application.Models.Identity.Authentication;
using RashaPrimeWeb.Application.Models.Identity.User;

namespace RashaPrimeWeb.Infrastructure.Implement
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApplication> _userManager;

        public UserService(UserManager<UserApplication> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ErrorOr<UserDto>> ChangePasswordUser(ChangePasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) Error.NotFound("User not found");


           
          var Res_RemovePassword=  await _userManager.RemovePasswordAsync(user);
          var res= Res_RemovePassword.Succeeded? await _userManager.AddPasswordAsync(user, model.Password): Res_RemovePassword;
            if(res.Succeeded)
            {
                return new UserDto
                {
                    Email = user.Email,
                    Firstname = user.FirstName,
                    Lastname=user.LastName,
                    IsAdmin =false,
                    Username= user.UserName,
                    PhoneNumber=user.PhoneNumber,
                }; 
            }
       
            return Error.Failure();
        }

        public async Task<ErrorOr<UserDto>> DeleteUser(UserDto model)
        {
            var User = await _userManager.FindByIdAsync(model.Id);
            if (User == null) Error.NotFound("User not found");

            if (User != null)
            {
                var res = await _userManager.DeleteAsync(User);
                if (res.Succeeded)
                {

                    return new UserDto();
                }

            }
            return Error.Failure();

        }

        public async Task<UserDto> GetUser(string userId)
        {
            var User = await _userManager.FindByIdAsync(userId);
            return new UserDto
            {
                Email = User.Email,
                Id = User.Id,
                Firstname = User.FirstName,
                Lastname = User.LastName,
                PhoneNumber= User.PhoneNumber,
                Username=User.UserName,
            };
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var Users = await _userManager.Users.ToListAsync();
            return Users.Select(q => new UserDto
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName,
                Username=q.UserName,
                PhoneNumber=q.PhoneNumber

            }).ToList();
        }

        public async Task<ErrorOr<UserDto>> UpdateUser(UserDto model)
        {
            var newmodel = new ErrorOr<UserDto>();
            var User = await _userManager.FindByIdAsync(model.Id);
           // _userManager.AddPasswordAsync(User,)
          
            if (User != null)
            {
                User.FirstName = model.Firstname!;
                User.LastName = model.Lastname!;
                User.UserName = model.Username;
                //User. = model.IsTeacher;
                await _userManager.UpdateAsync(User);
                return model;
            }
       
            return Error.Failure();

        }
    }
}
