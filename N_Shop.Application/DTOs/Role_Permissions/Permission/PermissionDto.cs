using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Role_Permissions.Permission
{
    public class PermissionDto : BaseDto, IPermissionDto
    {
        public string Name { get; set; }
    }
}
