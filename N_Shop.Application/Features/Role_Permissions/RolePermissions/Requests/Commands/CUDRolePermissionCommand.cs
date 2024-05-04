using MediatR;
using N_Shop.Application.DTOs.Role_Permissions.RolePermission;
using N_Shop.Application.Responses;

namespace N_Shop.Application.Features.Role_Permissions.RolePermissions.Requests.Commands
{
    public class CUDRolePermissionCommand : IRequest<Unit>
    {
        public CUDRolePermissionDto CUDRolePermissionDto { get; set; }
    }
}
