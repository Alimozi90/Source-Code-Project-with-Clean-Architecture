using N_Shop.Application.DTOs.Common;

namespace N_Shop.Application.DTOs.Role_Permissions.Permission
{
    public class UpdatePermissionDto : BaseDto, IPermissionDto
    {
        public string Name { get; set; }
    }
}
