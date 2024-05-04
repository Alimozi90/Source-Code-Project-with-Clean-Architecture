using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Role_Permissions.Role;

namespace N_Shop.Application.DTOs.Users.User
{
    public class UserDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public byte Status { get; set; }
        public RoleDto Role { get; set; }
    }
}
