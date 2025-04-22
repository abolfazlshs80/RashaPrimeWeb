using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RashaPrimeWeb.Application.Contracts.Identity;
using RashaPrimeWeb.Application.Models.Identity.Role;

namespace RashaPrimeWeb.Infrastructure.Implement
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserApplication> _userManager;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<UserApplication> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<ErrorOr<bool>> AddRole(AddRoleDto model)
        {
            var res = await _roleManager.CreateAsync(new IdentityRole { Name = model.RoleName });
            var newmodel = new ErrorOr<bool>();
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }

        public async Task<ErrorOr<bool>> AddRoleToUsers(AddRoleToUserDto model)
        {
            var res = new IdentityResult();
            var usersRoles = await GetRoles(model.UserId);
            var users = await _userManager.FindByIdAsync(model.UserId);
            if (!model.Selected)
            {
                if (await _userManager.IsInRoleAsync(users, model.RoleName))
                    res = await _userManager.RemoveFromRoleAsync(users, model.RoleName);
            }
            else
            {
                if (!await _userManager.IsInRoleAsync(users, model.RoleName))
                {
                    res = await _userManager.AddToRoleAsync(users, model.RoleName);

                }

            }

            var newmodel = new ErrorOr<bool>();
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }

        public async Task<ErrorOr<bool>> DeleteRoleFromUsers(AddRoleToUserDto model)
        {
            var res = await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(model.UserId), (await _roleManager.FindByIdAsync(model.RoleId)).Name);
            var newmodel = new ErrorOr<bool>();
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }

        public async Task<ErrorOr<bool>> DeleteRoleRole(string RoleId)
        {
            var res = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(RoleId));
            var newmodel = new ErrorOr<bool>();
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }

        public async Task<RolesDto> GetRole(string roleId)
        {
            return await (_roleManager.Roles.Where(a => a.Id == roleId).Select(a => new RolesDto()
            {
                RoleId = a.Id,
                RoleName = a.Name
            })).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RolesDto>> GetRoles()
        {

            return await _roleManager.Roles.Select(a => new RolesDto()
            {
                RoleId = a.Id,
                RoleName = a.Name
            }).ToListAsync();
        }
        public async Task<IEnumerable<AddRoleToUserDto>> GetRoles(string id)
        {
            var list = new List<AddRoleToUserDto>();
            foreach (var item in _roleManager.Roles)
            {
                list.Add(new AddRoleToUserDto()
                {
                    RoleId = item.Id,
                    UserId = id,
                    RoleName = item.Name,
                    Selected = (await IsInRole(new AddRoleToUserDto() { RoleId = item.Id, UserId = id })).Value
                });
            }
            return list;
        }

        public async Task<RolesDto> GetUserAndRoles(string UserId)
        {
            var model = _roleManager.Roles.Select(b => new RolesDto()
            {
                RoleId = b.Id,
                RoleName = b.Name
            }).Where(a => a.RoleId == UserId);
            return model.FirstOrDefault()!;
        }

        public async Task<ErrorOr<bool>> IsInRole(AddRoleToUserDto model)
        {
            var res = await _userManager.IsInRoleAsync(await _userManager.FindByIdAsync(model.UserId), ((await _roleManager.FindByIdAsync(model.RoleId)).Name));
            var newmodel = new ErrorOr<bool>();
            if (res)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }

        public async Task<ErrorOr<bool>> UpdateRole(AddRoleDto model)
        {
            var newmodel1 = await _roleManager.FindByIdAsync(model.RoleId);
            newmodel1.Id = model.RoleId;
            newmodel1.Name = model.RoleName;
            newmodel1.NormalizedName = model.RoleName.ToString().ToUpper();
            var res = await _roleManager.UpdateAsync(newmodel1);
            var newmodel = new ErrorOr<bool>();
            if (res.Succeeded)
            {
                return true;
            }
            else
            {
                return Error.Failure();
            }
            return newmodel;
        }
    }
}
