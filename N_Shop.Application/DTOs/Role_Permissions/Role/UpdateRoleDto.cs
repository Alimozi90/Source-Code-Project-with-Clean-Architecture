using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Role_Permissions.Role
{
    public class UpdateRoleDto : BaseDto, IRoleDto
    {
        public string Name { get; set; }
    }
}
