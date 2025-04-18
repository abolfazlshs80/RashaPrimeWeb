namespace RashaPrimeWeb.Application.Contracts.Identity
{
    public interface IRoleService
    {
        public Task<ResponseDto> AddRoleToUsers(AddRoleToUserDto model);
        public Task<ResponseDto> DeleteRoleFromUsers(AddRoleToUserDto model);
        public Task<ResponseDto> AddRole(AddRoleDto model);
        public Task<ResponseDto> UpdateRole(AddRoleDto model);
        public Task<ResponseDto> DeleteRoleRole(string RoleId);
        public Task<ResponseDto> IsInRole(AddRoleToUserDto model);
        public Task <IEnumerable< RolesDto>> GetRoles();
        public Task <IEnumerable<AddRoleToUserDto>> GetRoles(string id);
        public Task < RolesDto> GetRole(string roleId);
        public Task<RolesDto> GetUserAndRoles(string UserId);
    }
}
