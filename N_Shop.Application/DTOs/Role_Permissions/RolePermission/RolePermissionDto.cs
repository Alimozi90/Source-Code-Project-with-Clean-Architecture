using N_Shop.Application.DTOs.Common;
using N_Shop.Application.DTOs.Role_Permissions.Permission;

namespace N_Shop.Application.DTOs.Role_Permissions.RolePermission
{
    public class RolePermissionDto : BaseDto, IRolePermissionDto
    {
        public string RoleName { get; set; }
        public List<PermissionDto> PermissionDtos { get; set; }
        public List<int> PermissionsId { get; set; }
    }
}
