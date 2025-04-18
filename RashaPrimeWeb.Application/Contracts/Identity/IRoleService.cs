using RashaPrimeWeb.Application.Models.Identity.Role;

namespace RashaPrimeWeb.Application.Contracts.Identity
{
    public interface IRoleService
    {
        public Task<ErrorOr<bool>> AddRoleToUsers(AddRoleToUserDto model);
        public Task<ErrorOr<bool>> DeleteRoleFromUsers(AddRoleToUserDto model);
        public Task<ErrorOr<bool>> AddRole(AddRoleDto model);
        public Task<ErrorOr<bool>> UpdateRole(AddRoleDto model);
        public Task<ErrorOr<bool>> DeleteRoleRole(string RoleId);
        public Task<ErrorOr<bool>> IsInRole(AddRoleToUserDto model);
        public Task <IEnumerable< RolesDto>> GetRoles();
        public Task <IEnumerable<AddRoleToUserDto>> GetRoles(string id);
        public Task < RolesDto> GetRole(string roleId);
        public Task<RolesDto> GetUserAndRoles(string UserId);
    }
}
