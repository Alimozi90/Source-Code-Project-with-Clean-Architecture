using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Role_Permissions.RolePermission
{
    public class CUDRolePermissionDto : BaseDto, IRolePermissionDto
    {
        public List<int> PermissionsId { get; set; }
    }
}
