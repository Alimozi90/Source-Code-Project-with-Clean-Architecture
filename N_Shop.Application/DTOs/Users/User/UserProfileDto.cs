using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Role_Permissions.Role;

namespace N_Shop.Application.DTOs.Users.User
{
    public class UserProfileDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string? Avatar { get; set; }
        public byte Status { get; set; }
        public RoleDto Role { get; set; }
    }
}
