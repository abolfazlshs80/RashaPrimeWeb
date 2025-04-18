namespace RashaPrimeWeb.Application.Models.Identity.Role
{
    public class AddRoleToUserDto
    {
        public bool Selected { get; set; } = false;
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserId { get; set; }
    }
}
